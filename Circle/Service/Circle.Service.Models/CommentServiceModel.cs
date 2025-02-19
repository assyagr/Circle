using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Models
{
	public class CommentServiceModel : MetadataBaseServiceModel
	{
		public string Content { get; set; }

		public List<UserCommentReactionServiceModel> Reactions { get; set; }

		public List<CommentServiceModel> Replies { get; set; }

		public CommentServiceModel? Parent { get; set; }
	}
}
