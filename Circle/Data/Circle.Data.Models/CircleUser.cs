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

		//ADD MORE PROPERTIES?
		//username=email by default(IdentityUser) => change!
	}
}
