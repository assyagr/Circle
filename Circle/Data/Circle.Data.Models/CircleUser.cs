using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Data.Models
{
    public class CircleUser : IdentityUser  //i forgot how to inherit more
    {
        // in IdUser class:
        // public string Id 
        // also SecurityStamp 
        //Example Id for reference: e639a8c5-d9ab-43ec-81a3-e3f49a5c9ead

        //public string DisplayName { get; set; }

        //public UserProfile Profile { get; set; }

        //public DateTime CreatedAt { get; set; } = DateTime.UtcNow; //time apon creation

        public string? CircleRole { get; set; } //Admin, User ??

        public List<CircleUser>? Friends { get; set; }   //nullable...cuz im gonna need it :D
        public List<CircleFriendship> CircleFriendships { get; set; } = new List<CircleFriendship>(); //Friendship entities

        public List<CircleFriendship> OutgoingRequests { get; set; } = new List<CircleFriendship>();   //Adding thiss will remove the null stuff!

        public List<CircleFriendship> IncomingRequests { get; set; } = new List<CircleFriendship>();

        //dont know how to implement? public bool IsDeleted { get; set; } // soft delete

        //Suggestion:
        //public int GroupCricle {  get; set; } // App circle to have friend cricles/Groups but diffrent ig Ui is a circle :p
    }
}
