using Circle.Data.Models;
using Circle.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Comment
{
	public interface ICommentService : IGenericService<Data.Models.Comment, CommentServiceModel>
	{
	}
}
