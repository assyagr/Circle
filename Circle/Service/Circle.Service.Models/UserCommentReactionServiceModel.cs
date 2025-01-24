using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Models
{
	public class UserCommentReactionServiceModel : BaseServiceModel
	{
		public CircleUserServiceModel User { get; set; }

		public CommentServiceModel Comment { get; set; }

		public ReactionServiceModel Reaction { get; set; }
	}
}
