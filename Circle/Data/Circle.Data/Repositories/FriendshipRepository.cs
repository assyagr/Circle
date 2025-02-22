using Circle.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Circle.Data.Repositories
{
    public class FriendRequestRepository
    {
        private readonly CircleDbContext dbContext;

        public FriendRequestRepository(CircleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(FriendRequest friendRequest)
        {
            await dbContext.FriendRequests.AddAsync(friendRequest);
            await dbContext.SaveChangesAsync();
        }

        public IQueryable<FriendRequest> GetAll()
        {
            return dbContext.FriendRequests.AsQueryable();
        }

        public async Task<FriendRequest> GetByIdAsync(int id)
        {

            return await dbContext.FriendRequests.FindAsync(id);

        }

        public async Task DeleteAsync(FriendRequest friendRequest)
        {
            dbContext.FriendRequests.Remove(friendRequest);
            await dbContext.SaveChangesAsync();
        }
    }
}
