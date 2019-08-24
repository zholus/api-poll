using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Polling.Entities;

namespace Polling.Db
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.Property(entity => entity.Id);
                user.Property(entity => entity.Login);
                user.Property(entity => entity.Password);
                user.Property(entity => entity.AccessToken);

                user.HasIndex(entity => entity.Login).IsUnique();
                user.HasIndex(entity => entity.AccessToken).IsUnique();
            });
            
        }
    }
}