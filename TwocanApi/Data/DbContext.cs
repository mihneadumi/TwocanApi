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
        public DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.posts)
                .WithOne(p => p.author)
                .HasForeignKey(p => p.authorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Session>()
                .HasKey(s => s.username);

            base.OnModelCreating(modelBuilder);
        }
    }
}
