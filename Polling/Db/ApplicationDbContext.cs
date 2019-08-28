using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Polling.Entities;
using Polling.EntityConfigurations;

namespace Polling.Db
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PollEntityTypeConfiguration());
        }
    }
}