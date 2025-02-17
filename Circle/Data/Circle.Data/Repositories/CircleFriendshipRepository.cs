using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Circle.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Circle.Data.Repositories
{
    public class CircleFriendshipRepository : ICircleFriendshipReposiotry
    {
        protected readonly CircleDbContext _dbContext;

        public CircleFriendshipRepository(CircleDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<CircleFriendship> AddFriendAsync(Guid senderId, string addresseeUsername)
        {
            var sender = await _dbContext.Users.FindAsync(senderId);
            var addressee = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == addresseeUsername);

            if (sender == null || addressee == null)
            {
                throw new InvalidOperationException("Sender or Addressee not found.");
            }

            if (await AreFriendsAsync(senderId, Guid.Parse(addressee.Id)))
            {
                throw new InvalidOperationException("Users are already friends.");
            }

            var friendshipRequest = new CircleFriendship
            {
                SenderId = sender,
                SenderName = sender,
                AddresseeId = addressee,
                AddresseeName = addressee,
                Status = "Pending",
                CreatedOn = DateTime.UtcNow
            };

            await _dbContext.FriendshipRequests.AddAsync(friendshipRequest);
            await _dbContext.SaveChangesAsync();

            sender.Outgoing.Add(friendshipRequest);
            addressee.PendingFriendships.Add(friendshipRequest);

            await _dbContext.SaveChangesAsync();

            return friendshipRequest;
        }

        public async Task RemoveFriendAsync(Guid senderId, Guid addresseeId)
        {
            var friendship = await _dbContext.FriendshipRequests
                .FirstOrDefaultAsync(f => f.SenderId.Id == senderId.ToString() && f.AddresseeId.Id == addresseeId.ToString());

            if (friendship != null)
            {
                _dbContext.FriendshipRequests.Remove(friendship);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<bool> AreFriendsAsync(Guid senderId, Guid addresseeId)
        {
            return await _dbContext.FriendshipRequests
                .AnyAsync(f => f.SenderId.Id == senderId.ToString() && f.AddresseeId.Id == addresseeId.ToString() && f.Status == "Accepted");
        }

        public IQueryable<CircleFriendship> GetAllFriendships()
        {
            return _dbContext.FriendshipRequests.AsQueryable();
        }

        public async Task<CircleFriendship> GetFriendshipByIdAsync(Guid friendshipId)
        {
            return await _dbContext.FriendshipRequests.FindAsync(friendshipId);
        }

        public async Task UpdateFriendshipStatusAsync(Guid friendshipId, string status)
        {
            var friendship = await GetFriendshipByIdAsync(friendshipId);
            if (friendship != null)
            {
                friendship.Status = status;
                if (status == "Accepted")
                {
                    friendship.AcceptedOn = DateTime.UtcNow;
                }
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
