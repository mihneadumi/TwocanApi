using Microsoft.EntityFrameworkCore;
using TwocanApi.Models;

namespace TwocanApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.posts)
                .WithOne(p => p.author)
                .HasForeignKey(p => p.authorId)
                .OnDelete(DeleteBehavior.Cascade);

            // You can define other relationships here

            base.OnModelCreating(modelBuilder);
        }
    }
}
