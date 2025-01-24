using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service.Models
{
	internal class UserProfileServiceModel // nz kwo nasledqwa
	{
		public CircleUserServiceModel User { get; set; }

		public string Bio { get; set; }

		public AttachmentServiceModel ProfilePicture { get; set; }

		public List<CircleUserServiceModel> Friends { get; set; }

		public List<CircleUserServiceModel> Followers { get; set; }

		public List<CircleUserServiceModel> Following { get; set; }

		public List<CircleUserServiceModel> Posts { get; set; }
	}
}
