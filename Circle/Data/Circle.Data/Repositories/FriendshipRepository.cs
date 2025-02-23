using Circle.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Circle.Data.Repositories
{
    using FriendRequestModel = Circle.Data.Models.FriendRequest;

    public class FriendRequestRepository
    {
        private readonly CircleDbContext dbContext;

        public FriendRequestRepository(CircleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateAsync(FriendRequestModel friendRequest)
        {
            await dbContext.FriendRequests.AddAsync(friendRequest);
            await dbContext.SaveChangesAsync();
        }

        public IQueryable<FriendRequestModel> GetAll()
        {
            return dbContext.FriendRequests;
        }

        public async Task<FriendRequestModel?> GetByIdAsync(int id)
        {
            return await dbContext.FriendRequests.FirstOrDefaultAsync(fr => fr.Id == id);
        }

        public async Task DeleteAsync(FriendRequestModel friendRequest)
        {
            dbContext.FriendRequests.Remove(friendRequest);
            await dbContext.SaveChangesAsync();
        }
    }
}
