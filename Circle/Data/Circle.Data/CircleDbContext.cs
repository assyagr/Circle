using Circle.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Circle.Data
{
    public class CircleDbContext : IdentityDbContext<CircleUser>
    {
        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<CirclePost> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Reaction> Reactions { get; set; }

		public CircleDbContext(DbContextOptions<CircleDbContext> options)
            : base(options)
        {
        }

	}
}
