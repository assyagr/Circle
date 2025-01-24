using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Models
{
	public class UserPostReactionServiceModel : BaseServiceModel
	{
		public CircleUserServiceModel User { get; set; }

		public CirclePostServiceModel Post { get; set; }

		public ReactionServiceModel Reaction { get; set; }
	}
}
