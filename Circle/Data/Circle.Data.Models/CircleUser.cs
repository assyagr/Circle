using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Data.Models
{
	public class CircleUser : IdentityUser
	{
		public Attachment ProfilePicture { get; set; }

		public List<CircleUser> Friends { get; set; }

		public List<CircleUser> Followers { get; set; }

		public List<CircleUser> Following { get; set; }

		//ADD MORE PROPERTIES?
		//username=email?
	}
}
