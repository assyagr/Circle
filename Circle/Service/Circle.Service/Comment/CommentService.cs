using Circle.Data.Models;
using Circle.Data.Repositories;
using Circle.Service.Mappings;
using Circle.Service.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Comment
{
	public class CommentService : ICommentService
	{
		private readonly CommentRepository commentRepository;
		private readonly CirclePostRepository circlePostRepository;
		private readonly ICircleUserService circleUserService;

		public CommentService(CommentRepository commentRepository, CirclePostRepository circlePostRepository, ICircleUserService circleUserService)
		{
			this.commentRepository = commentRepository;
			this.circlePostRepository = circlePostRepository;
			this.circleUserService = circleUserService;
		}

		public Task<CommentServiceModel> CreateAsync(CommentServiceModel model)
		{
			throw new NotImplementedException();
		}

		public async Task<CommentServiceModel> CreateReplyOnComment(CommentServiceModel model, string postId)
		{
			Data.Models.Comment entity = model.ToEntity();

			Data.Models.Comment? parent = await InternalGetByIdAsync(model.Parent.Id);

			entity.Parent = parent;

			entity = await this.commentRepository.CreateAsync(entity);

			CirclePost commentPost = await (this.circlePostRepository.GetAll()
					.Include(p => p.Content)
				.Include(p => p.Hashtags)
				.Include(p => p.TaggedUsers)
				.Include(p => p.Reactions)
				.Include(p => p.Comments)
					.ThenInclude(upc => upc.Comment)
						.ThenInclude(c => c.Parent)
				.Include(p => p.CreatedBy)
				.Include(p => p.UpdatedBy)
				.Include(p => p.DeletedBy))
					.SingleOrDefaultAsync(cp => cp.Id == postId);

			commentPost.Comments.Add(new UserPostComment
			{
				Comment = entity,
				Post = commentPost,
				User = (await this.circleUserService.GetCurrentUserAsync())
			});

			await this.circlePostRepository.EditAsync(commentPost);
			return entity.ToModel(CommentMappingsContext.Reaction);
		}

		private async Task<Data.Models.Comment> InternalGetByIdAsync(string id)
		{
			return await InternalGetAll().SingleOrDefaultAsync(comment => comment.Id == id);
		}

		private IQueryable<Data.Models.Comment> InternalGetAll()
		{
			return commentRepository.GetAll()
				.Include(c => c.Reactions)
				.Include(c => c.Replies)
				.Include(c => c.Parent)
				.Include(c => c.CreatedBy)
				.Include(c => c.UpdatedBy)
				.Include(c => c.DeletedBy);
		}

		public Task<CommentServiceModel> DeleteAsync(string id)
		{
			throw new NotImplementedException();
		}

		public Task<CommentServiceModel> EditAsync(CommentServiceModel model)
		{
			throw new NotImplementedException();
		}

		public IQueryable<CommentServiceModel> GetAll()
		{
			return this.InternalGetAll().Select(c => c.ToModel(CommentMappingsContext.User));
		}

		public async Task<IQueryable<CommentServiceModel>> GetAllNoParentByPostId(string postId)
		{
			CirclePost post = await this.circlePostRepository.GetAll()
				.Include(p => p.Comments)
					.ThenInclude(upc => upc.Comment)
						.ThenInclude(c => c.Parent)
				.Include(p => p.Comments)
					.ThenInclude(c => c.Comment)
						.ThenInclude(c => c.Replies)
				.Include(p => p.Comments)
					.ThenInclude(c => c.Comment)
						.ThenInclude(c => c.Reactions)
							.ThenInclude(ucr => ucr.Reaction)
								.ThenInclude(r => r.Emote)
				.SingleOrDefaultAsync(p => p.Id == postId);

			if (post == null)
			{
				throw new ArgumentException("No thread exists with id - " + postId);
			}

			return post.Comments
				.Where(c => c.Comment.Parent == null)
				.Select(c => c.Comment.ToModel(CommentMappingsContext.Parent))
				.AsQueryable();
		}
	}
}
