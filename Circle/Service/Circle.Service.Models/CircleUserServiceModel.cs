using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Models
{
	public class CircleUserServiceModel : IdentityUser
	{
		//public string DisplayName { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.UtcNow; //time apon creation 

		//public string TypeOfAurdiance { get; set; } //who he is (audiance) ???

		public string CircleRole { get; set; } //Admin, User??

		//public bool IsDeleted { get; set; } // soft delete 
	}
}
