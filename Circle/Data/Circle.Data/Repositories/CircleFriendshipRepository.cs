using Circle.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Circle.Data.Repositories
{
    public class CircleFriendshipRepository
    {
        private readonly CircleDbContext _context;

        public CircleFriendshipRepository(CircleDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(CircleFriendship friendship)
        {
            await _context.Friendships.AddAsync(friendship);
        }

        public async Task<CircleFriendship> GetByIdAsync(string id)
        {
            return await _context.Friendships //possible null? Tho ill never call it with null stuff?
                .Include(f => f.CreatedById)
                .Include(f => f.SentToId)
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
