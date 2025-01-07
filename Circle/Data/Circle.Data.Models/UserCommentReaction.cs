using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Data.Models
{
	public class UserCommentReaction : BaseEntity
	{
		public CircleUser User { get; set; }

		public Comment Comment { get; set; }

		public Reaction Reaction { get; set; }
	}
}
