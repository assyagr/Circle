using Circle.Data;
using Circle.Data.Models;
using Circle.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace Circle.Service
{
    public class CircleFriendshipService
    {
        private readonly CircleFriendshipRepository _friendshipRepository;
        private readonly CircleDbContext _context;

        public CircleFriendshipService(CircleFriendshipRepository friendshipRepository, CircleDbContext context)
        {
            _friendshipRepository = friendshipRepository;
            _context = context;
        }
        //public async Task SendFriendRequestAsync(string senderId, string receiverId)
        public async Task SendFriendRequestAsync(string receiverId)
        {
            var friendship = new CircleFriendship
            {
                CreatedById = "1", //i actually made it work... i think. Testing it without it
                SentToId = receiverId, 
                CreatedOn = DateTime.UtcNow,
                Status = "Pending"
            };

            await _friendshipRepository.AddAsync(friendship);
            await _context.SaveChangesAsync();
        }

        public async Task AcceptFriendRequestAsync(string friendshipId)
        {
            var friendship = await _friendshipRepository.GetByIdAsync(friendshipId);
            if (friendship != null && friendship.Status == "Pending")
            {
                friendship.Status = "Accepted";
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeclineFriendRequestAsync(string friendshipId)
        {
            var friendship = await _friendshipRepository.GetByIdAsync(friendshipId);
            if (friendship != null && friendship.Status == "Pending")
            {
                friendship.Status = "Declined";
                await _context.SaveChangesAsync();
            }
        }
    }
}