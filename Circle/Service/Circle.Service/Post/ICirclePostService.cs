using Circle.Data.Models;
using Circle.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Post
{
	public interface ICirclePostService
	{
		public interface ICirclePostService : IGenericService<CirclePost, CirclePostServiceModel>
		{
		}

		Task<CirclePostServiceModel> CreateAsync(CirclePostServiceModel model);

		Task<CirclePost> InternalCreateAsync(CirclePost model);

	}
}
