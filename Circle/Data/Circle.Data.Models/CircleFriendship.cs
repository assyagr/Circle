using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Data.Models
{
    public class CircleFrienship : BaseEntity //is metadata needed?
    {
        public CircleUser SenderId { get; set; } //who is sending the request // why is the id a string in base?
        public CircleUser SenderName { get; set; } //Name of sender to attach to the request
       
        

        public CircleUser AddresseeId { get; set; } 
        public CircleUser AddresseeName { get; set; } //Name of the person receiving the request

        public string Status { get; set; } //Pending, Accepted, Declined, Blocked ect.

        public DateTime CreatedOn { get; set; } 
        public DateTime AcceptedOn { get; set; }




    }
}
