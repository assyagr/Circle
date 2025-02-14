using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Data.Models
{
	public class CirclePost : MetadataBaseEntity
	{
		public List<Attachment>? Content { get; set; }

		public string? Caption { get; set; }

		public List<UserPostReaction>? Reactions { get; set; }

		public List<UserPostComment>? Comments { get; set; }

		public List<CircleUser>? TaggedUsers { get; set; }

		public List<Hashtag>? Hashtags { get; set; }
    }
}
