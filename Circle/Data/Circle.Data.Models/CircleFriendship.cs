using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Data.Models
{
   public class CircleFriendship : BaseEntity
    {

        public CircleUser CreatedBy { get; set; } //This ISNT a forigen key property

        public string CreatedById { get; set; } //THIS IS the forigen key property!!!   

        public CircleUser SentTo { get; set; } //"navigation property"?

        public string SentToId { get; set; } 

        public string Status { get; set; } //Pending, Accepted, Discarded// ONLY 3

        public DateTime DateTime { get; set; } = DateTime.UtcNow; //time apon creation

    }
}
