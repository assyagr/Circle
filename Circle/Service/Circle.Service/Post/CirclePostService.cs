using Circle.Data.Models;
using Circle.Data.Repositories;
using Circle.Service.Models;
using Circle.Service.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Circle.Service.Hashtag;

namespace Circle.Service.Post
{
	public class CirclePostService : ICirclePostService
	{
		private readonly CirclePostRepository circlePostRepository;
		private readonly HashtagRepository hashtagRepository;
		private readonly CommentRepository commentRepository;
		private readonly CircleUserRepository circleUserRepository;
		private readonly ICircleUserService circleUserService;

		public CirclePostService(CirclePostRepository circlePostRepository, CircleUserRepository circleUserRepository, HashtagRepository hashtagRepository, CommentRepository commentRepository, ICircleUserService circleUserService)
		{
			this.circlePostRepository = circlePostRepository;
			this.circleUserRepository = circleUserRepository;
			this.hashtagRepository = hashtagRepository;
			this.commentRepository = commentRepository;
			this.circleUserService = circleUserService;
		}

		public async Task<CirclePostServiceModel> CreateAsync(CirclePostServiceModel model)
		{
			CirclePost circlePost = model.ToEntity();

			if (circlePost.Hashtags != null)
			{
				circlePost.Hashtags = circlePost.Hashtags.Select(async hashtag =>
				{
					return (await this.hashtagRepository.CreateAsync(hashtag));
				}).Select(h => h.Result).ToList();
			}

			circlePost.TaggedUsers = new List<CircleUser>();
			if (model.TaggedUsers != null)
			{
				foreach (var taggedUser in model.TaggedUsers)
				{
					List<CircleUser> allUsers = this.circleUserRepository.GetAll().ToList();
					CircleUser user = allUsers.Single(user => user.UserName == taggedUser.UserName);
					circlePost.TaggedUsers.Add(user);
				}
			}

			await circlePostRepository.CreateAsync(circlePost);

			return circlePost.ToModel();
		}

		public async Task<CirclePostServiceModel> GetByIdAsync(string id)
		{
			return (await this.InternalGetAll().SingleOrDefaultAsync(post => post.Id == id))?.ToModel();
		}

		public IQueryable<CirclePostServiceModel> GetAll()
		{
			return this.InternalGetAll()
				.Select(p => p.ToModel());
		}

		private async Task<CirclePost> InternalGetByIdAsync(string id)
		{
			return await this.InternalGetAll().SingleOrDefaultAsync(post => post.Id == id);
		}

		private IQueryable<CirclePost> InternalGetAll()
		{
			return circlePostRepository.GetAll()
				.Include(p => p.Content)
				//.Include(p => p.Caption)
				.Include(p => p.Hashtags)
				.Include(p => p.TaggedUsers)
				.Include(p => p.Reactions)
				.Include(p => p.Comments)
					.ThenInclude(upc => upc.Comment)
				.Include(p => p.CreatedBy)
				//.Include(p => p.CreatedOn)
				.Include(p => p.UpdatedBy)
				.Include(p => p.DeletedBy);
		}

		public async Task<CirclePostServiceModel> DeleteAsync(string id)
		{
			CirclePost deletePost = await circlePostRepository.GetAll().SingleOrDefaultAsync(p => p.Id == id);

			if (deletePost == null)
			{
				throw new NullReferenceException($"No post found with id - {id}.");
			}

			await circlePostRepository.DeleteAsync(deletePost);

			return deletePost.ToModel();
		}

		public async Task<CirclePostServiceModel> EditAsync(CirclePostServiceModel model, List<string> allTaggedUsers, List<string> newHashtags)
		{
			CirclePost editCirclePost = await InternalGetByIdAsync(model.Id);

			// TODO: fix this....  
			List<CircleUser> taggedUsers = circleUserRepository.GetAll().ToList().Where(u => allTaggedUsers.Contains(u.UserName)).ToList();
			editCirclePost.TaggedUsers = taggedUsers;

			List<Data.Models.Hashtag> oldHashtags = editCirclePost.Hashtags;

			foreach (var hashtag in newHashtags)
			{
				if (!oldHashtags.Select(h => h.Label).Contains(hashtag))
				{
					Data.Models.Hashtag newHashtag = await hashtagRepository.CreateAsync(new Data.Models.Hashtag { Label = hashtag });
					editCirclePost.Hashtags.Add(newHashtag);

				}
			}

			foreach (var hashtag in oldHashtags)
			{
				if (!newHashtags.Contains(hashtag.Label))
				{
					//editCirclePost.Hashtags.Remove(hashtag);
					await hashtagRepository.DeleteAsync(hashtag);
				}
			}

			editCirclePost.Caption = model.Caption;

			await circlePostRepository.EditAsync(editCirclePost);
			return editCirclePost.ToModel();
		}

		public async Task<CommentServiceModel> CreateCommentOnPost(CommentServiceModel model, string postId, string? parentCommentId = null)
		{
			Data.Models.Comment entity = model.ToEntity();

			if (parentCommentId != null)
			{
				Data.Models.Comment? parent = await commentRepository.GetAll()
					.SingleOrDefaultAsync(c => c.Id == parentCommentId);

				if (parent == null)
				{
					throw new ArgumentException("Parent comment not found for id - " + parentCommentId);
				}

				entity.Parent = parent;
			}

			entity = await this.commentRepository.CreateAsync(entity);

			CirclePost commentPost = await this.InternalGetByIdAsync(postId);

			commentPost.Comments.Add(new UserPostComment
			{
				Comment = entity,
				Post = commentPost,
				User = (await this.circleUserService.GetCurrentUserAsync())
			});

			await this.circlePostRepository.EditAsync(commentPost);
			return entity.ToModel(CommentMappingsContext.Reaction);
		}

		public Task<CirclePostServiceModel> EditAsync(CirclePostServiceModel model)
		{
			throw new NotImplementedException();
		}
	}
}
