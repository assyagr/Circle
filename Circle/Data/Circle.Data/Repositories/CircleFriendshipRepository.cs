using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Circle.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Circle.Data.Repositories
{                           
    public class FriendshipRepository : ICircleFriendshipReposiotry
    {
        protected readonly CircleDbContext _dbContext;

        public FriendshipRepository(CircleDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<CircleFrienship> AddFriendAsync(Guid senderId, Guid addresseeId)
        {
            if (await AreFriendsAsync(senderId, addresseeId))
            {
                throw new InvalidOperationException("Users are already friends.");
            }
            //lookup of a single entity when its primary key is known https://learn.microsoft.com/en-us/ef/core/change-tracking/entity-entries#find-and-findasync
            var sender = await _dbContext.Users.FindAsync(senderId); 
            var addressee = await _dbContext.Users.FindAsync(addresseeId);
            string status = "Pending";

            if (sender == null || addressee == null)
            {
                throw new InvalidOperationException("Sender or Addressee not found.");
            }

            var friendshipRequest = new CircleFrienship
            {
                SenderId = sender,
                SenderName = sender,
                AddresseeId = addressee,
                AddresseeName = addressee,
                Status = status,
                CreatedOn = DateTime.Now
            };

            await _dbContext.FrienshipRequests.AddAsync(friendshipRequest);
            await _dbContext.SaveChangesAsync();
            return friendshipRequest;
        }

        public async Task RemoveFriendAsync(Guid senderId, Guid addresseId )
        {

            throw new NotImplementedException();    


        }

        public async Task<bool> AreFriendsAsync(Guid SenderId, Guid AddresseId)
        {
          //  return await this._dbContext.FrienshipRequests.AnyAsync();

            throw new NotImplementedException();
        }

        public IQueryable<CircleFrienship> GetAllFriendships()
        {
            return this._dbContext.FrienshipRequests.AsQueryable();
        }
    }
}
