using Circle.Data.Models;
using Circle.Data.Extensions;
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

        public DbSet<Hashtag> Hashtags { get; set; }

        public CircleDbContext(DbContextOptions<CircleDbContext> options)
            : base(options)
        {
        }

		//Configured the relationship between CirclePost and CircleUser
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<CirclePost>()
				.HasMany(cp => cp.TaggedUsers)
				.WithMany();

			modelBuilder.Entity<CirclePost>()
				.HasMany(cp => cp.Hashtags)
				.WithMany();

			modelBuilder.Entity<CirclePost>()
				.HasMany(cp => cp.Content)
				.WithMany();

			modelBuilder.ConfigureMetadataEntity<CirclePost>();

			modelBuilder.Entity<CircleUser>()
				.HasMany(cu => cu.Posts)
				.WithOne()
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.ConfigureMetadataEntity<Hashtag>();

			base.OnModelCreating(modelBuilder);
		}
    }
}
