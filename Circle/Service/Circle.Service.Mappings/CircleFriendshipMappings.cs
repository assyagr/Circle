using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Circle.Data.Models;
using Circle.Service.Models;

namespace Circle.Service.Mappings
{
    public class CircleFriendshipMappings
    {
        // Create a new friendship request
        public CircleFriendship CreateRequest(CircleUser sender, CircleUser addressee)
        {
            return new CircleFriendship
            {
                SenderId = sender,
                SenderName = sender,
                AddresseeId = addressee,
                AddresseeName = addressee,
                CreatedOn = DateTime.UtcNow,
                Status = "Pending"
            };
        }

        // Check if a user has pending requests
        public bool HasPendingRequest(CircleUser user, string requestId)
        {
            return user.PendingFriendships.Any(f => f.Id == requestId);
        }

        // Update the status of a friendship request
        public void UpdateRequestStatus(CircleFriendship request, string status)
        {
            request.Status = status;
            if (status == "Accepted")
            {
                request.AcceptedAt = DateTime.UtcNow;
            }
        }

        // Delete a friendship request
        public void DeleteRequest(CircleUser user, string requestId)
        {
            var request = user.PendingFriendships.FirstOrDefault(f => f.Id == requestId);
            if (request != null)
            {
                user.PendingFriendships.Remove(request);
            }
        }
    }
}
