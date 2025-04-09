using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Circle.Data.Models;

namespace Circle.Data.Repositories
{
    public class CircleFriendshipReposiotry : ICircleFriendshipReposiotry
    {
        private readonly CircleDbContext _context;

        public CircleFriendshipReposiotry(CircleDbContext context)
        {
            _context = context;
        }

        public void Add(CircleFriendship friendship)
        {
            // Add the friendship to the database
            _context.CircleFriendships.Add(friendship);

            // Update the sender's outgoing list
            var sender = _context.Users.Find(friendship.CreatedById); //This should work if i make it get loged in user id
            if (sender != null)
            {
                sender.OutgoingCircleFriendships.Add(friendship);
            }

            // Update the receiver's incoming list
            var receiverId = _context.Users.Find(friendship.SentToId); //still a string? Find wants a know primary key"
            if (receiverId != null)
            {
                receiverId.IncomingCircleFriendships.Add(friendship);
            }

            // Save changes to the database
            _context.SaveChanges();
        }
    }
}
