using Circle.Data.Models;  
using Circle.Service.Models;  

namespace Circle.Service.Models
{
    public class FriendRequestServiceModel
    {
        public int Id { get; set; }
        public required string SenderId { get; set; }
        public required string ReceiverId { get; set; }
    }
}
