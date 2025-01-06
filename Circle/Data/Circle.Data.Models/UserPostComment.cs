using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Data.Models
{
	public class UserPostComment : BaseEntity
	{
		public CircleUser User { get; set; }

		public CirclePost Post { get; set; }

		public Comment Comment { get; set; }
	}
}
