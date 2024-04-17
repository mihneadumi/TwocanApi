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
                .WithOne(p => p.AuthorId)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            // You can define other relationships here

            base.OnModelCreating(modelBuilder);
        }

        // Uncomment this if you want to configure the connection string here
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseMySql("your_mysql_connection_string");
        //     base.OnConfiguring(optionsBuilder);
        // }
    }
}
