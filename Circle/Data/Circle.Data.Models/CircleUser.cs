using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Data.Models
{
	public class CircleUser : IdentityUser //i forgot how to inherit more
	{
        public string Id { get; set; } = Guid.NewGuid().ToString(); //Yes i have not inheritated the BaseEnitity -S
         //Example Id for reference: e639a8c5-d9ab-43ec-81a3-e3f49a5c9ead
        public string DisplayName { get; set; }
		public string Bio {  get; set; }	
		public Attachment ProfilePictureCloudUrl { get; set; }


		
		public string Email {  get; set; }	
		public string Password { get; set; }
		public string PasswordHash { get; set; } //For safty? 
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; //time apon creation 



        public List<CircleUser> Friends { get; set; }	
		public List<CircleUser> Followers { get; set; }
		public List<CircleUser> Following { get; set; }		

		//Suggestion:
		//public int GroupCricle {  get; set; } // App circle to have friend cricles/Groups but diffrent ig Ui is a circle :p
	



		///public Attachment ProfilePicture { get; set; }

		///public List<CircleUser> Friends { get; set; }

		///public List<CircleUser> Followers { get; set; }

		///public List<CircleUser> Following { get; set; }

		//ADD MORE PROPERTIES?
		//username=email?
	}
}
