using System;

namespace Circle.Service.Models
{
    public class CircleFriendshipServiceModel
    {
        public string Id { get; set; }
        public CircleUserServiceModel SenderId { get; set; }
        public string SenderName { get; set; }
        public CircleUserServiceModel AddresseeId { get; set; }
        public string AddresseeName { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? AcceptedOn { get; set; }
    }
}
