using System.Threading.Tasks;
using Circle.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Circle.Data.Repositories
{
    public class CircleUserRepository
    {
        private readonly CircleDbContext dbContext;

        public CircleUserRepository(CircleDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<CircleUser> GetByIdAsync(string id)
        {

            return await dbContext.CircleUsers.FindAsync(id);

        }

        public async Task UpdateAsync(CircleUser user)
        {
            dbContext.CircleUsers.Update(user);
            await dbContext.SaveChangesAsync();
        }
    }
}
public class CircleUser
{
    public string Id { get; set; }
    

  
    public ICollection<CircleUser> Friends { get; set; } = new HashSet<CircleUser>();
}
