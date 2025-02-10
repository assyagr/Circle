using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Data.Models
{
	public class UserProfile // nz kakwo nasledqwa oshte
	{
		public CircleUser User { get; set; }

		public string? Bio { get; set; }

		public Attachment? ProfilePicture { get; set; }

		public List<CircleUser>? Friends { get; set; }

		public List<CircleUser>? Followers { get; set; }

		public List<CircleUser>? Following { get; set; }

		public List<CirclePost>? Posts { get; set; } //Posts by user
	}
}
