using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Models
{
	public class CirclePostServiceModel : MetadataBaseServiceModel
	{
		public List<AttachmentServiceModel> Content { get; set; }

		public string Caption { get; set; }

		public List<UserPostReactionServiceModel> Reactions { get; set; }

		public List<UserPostCommentServiceModel> Comments { get; set; }

		public List<CircleUserServiceModel> TaggedUsers { get; set; }

		public bool IsDeleted { get; set; }
	}
}
