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

        public DbSet<CircleFriendship> CircleFriendships { get; set; }

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





            // One user to many friendship requests
            modelBuilder.Entity<CircleFriendship>()
                .HasOne(cf => cf.CreatedBy)
                .WithMany(cu => cu.OutgoingCircleFriendships)
                .HasForeignKey(cf => cf.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            // One user to many friendship requests
            modelBuilder.Entity<CircleFriendship>()
                .HasOne(cf => cf.SentTo) //navigation property??? / a single one to one property? 
                .WithMany(cu => cu.IncomingCircleFriendships) //defined in circleuser as a CF it all makes sense now
                .HasForeignKey(cf => cf.SentToId)
                .OnDelete(DeleteBehavior.Restrict); // it works




            modelBuilder.ConfigureMetadataEntity<Hashtag>();

			base.OnModelCreating(modelBuilder);
		}
    }
}
