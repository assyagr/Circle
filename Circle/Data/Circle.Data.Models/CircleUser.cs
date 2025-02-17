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

        
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; //time apon creation 

        public string TypeOfInterest { get; set; } //who he is (audiance) we will need this in the futuer, i think.

        public string? CircleRole { get; set; } //Admin, User ??


        public List<CircleFriendship> AcceptedFrienships { get; set; } //List of friendship "contract ids"

        //public List<CircleFriendship> PendingRequests { get; set; }  

        public List<CircleFriendship> Outgoing {  get; set; }

        public List<CircleFriendship> PendingFriendships { get; set; } = new List<CircleFriendship>(); 
    }


}

