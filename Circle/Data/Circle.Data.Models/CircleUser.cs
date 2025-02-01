﻿using Microsoft.AspNetCore.Identity;
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

        //dont need? // public string DisplayName { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; //time apon creation 

        //public string TypeOfAudience { get; set; } //who he is (audiance) ???

        public string? CircleRole { get; set; } //Admin, User ??

        //dont know how to implement? public bool IsDeleted { get; set; } // soft delete

        //Suggestion:
        //public int GroupCricle {  get; set; } // App circle to have friend cricles/Groups but diffrent ig Ui is a circle :p
    }
}
