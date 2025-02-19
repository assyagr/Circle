using Circle.Data.Models;
using Circle.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Post
{
	public interface ICirclePostService : IGenericService<CirclePost, CirclePostServiceModel>
	{

		Task<CirclePostServiceModel> CreateAsync(CirclePostServiceModel model);

		IQueryable<CirclePostServiceModel> GetAll();

		Task<CirclePostServiceModel> GetByIdAsync(string id);

		Task<CirclePostServiceModel> EditAsync(CirclePostServiceModel model, List<string> allTaggedUsers, List<string> newHashtags);

		Task<CirclePostServiceModel> DeleteAsync(string id);

		Task<CommentServiceModel> CreateCommentOnPost(CommentServiceModel model, string postId, string? parentId = null);
	}
}
