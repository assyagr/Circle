using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Circle.Data
{
    public class CircleDbContext : IdentityDbContext
    {
        public CircleDbContext(DbContextOptions<CircleDbContext> options)
            : base(options)
        {
        }
    }
}
