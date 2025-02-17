using System;
using System.Threading.Tasks;
using Circle.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Circle.Data.Repositories
{
    public class CircleFriendshipRepository : ICircleFriendshipReposiotry
    {
        private readonly CircleDbContext _context;

        public CircleFriendshipRepository(CircleDbContext context)
        {
            _context = context;
        }

        public async Task CreateRequest(string senderId, string addresseeUsername)
        {
            var sender = await _context.Users.FindAsync(senderId);
            var addressee = await _context.Users.FirstOrDefaultAsync(u => u.UserName == addresseeUsername);

            if (sender == null || addressee == null)
            {
                throw new ArgumentException("Invalid sender or addressee.");
            }

            var friendship = new CircleFriendship
            {
                SenderId = sender,
                SenderName = sender.UserName, //possible lazy fix is to just aks your friend to give you their id ???
                AddresseeId = addressee,
                AddresseeName = addressee.UserName,
                Status = "Pending",
                CreatedOn = DateTime.Now
            };

            sender.Outgoing.Add(friendship);
            addressee.PendingRequests.Add(friendship);

            _context.CricleFriendships.Add(friendship);
            await _context.SaveChangesAsync();
        }
    }
}