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
            // Add the CircleFriendship entity to the DbSet
            _context.CircleFriendships.Add(friendship);

            // Add the CreatedBy user to the DbSet if not already tracked
            if (_context.Users.Any(u => u.Id == friendship.CreatedById))
            {
                _context.Users.Add(friendship.CreatedBy);
            }

            // Add the SentTo user to the DbSet if not already tracked
            if (!_context.Users.Any(u => u.Id == friendship.SentToId))
            {
                _context.Users.Add(friendship.SentTo);
            }

            // Save all changes to the database
            _context.SaveChanges();
        }
    }
}
