using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Data.Models
{
    public class CircleFriendship : BaseEntity //is metadata needed?
    {
        public CircleUser SenderId { get; set; } //Autofill when creating a friendship entity 
        public CircleUser SenderName { get; set; } //Autofill
       
        

        public CircleUser AddresseeId { get; set; } //Autofill
        public CircleUser AddresseeName { get; set; } //Used for searching? 

        public string Status { get; set; } //Pending, Accepted, Declined, Blocked ect.

        public DateTime CreatedOn { get; set; } = DateTime.Now; //Autofill
        public DateTime? AcceptedOn { get; set; } //? make it nullable?




    }
}
