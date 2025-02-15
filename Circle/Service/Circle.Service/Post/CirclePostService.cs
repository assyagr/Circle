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

namespace Circle.Service.Post
{
	public class CirclePostService : ICirclePostService
	{
		private readonly CirclePostRepository circlePostRepository;
		private readonly HashtagRepository hashtagRepository;
		private readonly CircleUserRepository circleUserRepository;

		public CirclePostService(CirclePostRepository circlePostRepository, CircleUserRepository circleUserRepository, HashtagRepository hashtagRepository)
		{
			this.circlePostRepository = circlePostRepository;
			this.circleUserRepository = circleUserRepository;
			this.hashtagRepository = hashtagRepository;
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

		public Task<CirclePost> InternalCreateAsync(CirclePost model)
		{
			throw new NotImplementedException();
		}
	}
}
