using Circle.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Comment
{
	public class CommentService : ICommentService
	{
		public Task<CommentServiceModel> CreateAsync(CommentServiceModel model)
		{
			throw new NotImplementedException();
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
			throw new NotImplementedException();
		}
	}
}
