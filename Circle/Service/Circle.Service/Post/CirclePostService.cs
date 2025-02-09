using Circle.Data.Models;
using Circle.Data.Repositories;
using Circle.Service.Models;
using Circle.Service.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Post
{
	public class CirclePostService : ICirclePostService
	{
		private readonly CirclePostRepository circlePostRepository;

		public CirclePostService(CirclePostRepository circlePostRepository)
		{
			this.circlePostRepository = circlePostRepository;
		}

		public async Task<CirclePostServiceModel> CreateAsync(CirclePostServiceModel model)
		{
			CirclePost circlePost = model.ToEntity();

			await circlePostRepository.CreateAsync(circlePost);

			return circlePost.ToModel();
		}

		public Task<CirclePost> InternalCreateAsync(CirclePost model)
		{
			throw new NotImplementedException();
		}
	}
}
