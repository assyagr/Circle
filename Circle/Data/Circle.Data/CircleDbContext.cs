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

        public DbSet<CircleFriendship> CricleFriendships { get; set; }


        public CircleDbContext(DbContextOptions<CircleDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configured the relationship between CirclePost and CircleUser
            modelBuilder.Entity<CirclePost>()
                .HasOne(p => p.CreatedBy)
                .WithOne()
                .HasForeignKey("CreatedById")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CirclePost>()
                .HasOne(p => p.UpdatedBy)
                .WithOne()
                .HasForeignKey("UpdatedById")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CirclePost>()
                .HasOne(p => p.DeletedBy)
                .WithOne()
                .HasForeignKey("DeletedById")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
