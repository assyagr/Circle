using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Data.Models
{
    public class CircleFriendship
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CreatedById { get; set; } // Id of the CircleUser sender...Its apprenatly just a string...?

        public string SentToId { get; set; } // One to one relationship with CircleUser receiver

        public DateTime CreatedOn { get; set; }

        public string Status { get; set; } // Pending, Accepted, Declined 
    }
}
