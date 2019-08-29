using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Polling.Entities;

namespace Polling.EntityConfigurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(user => user.Id);
            builder.Property(user => user.Login);
            builder.Property(user => user.Password);
            builder.Property(user => user.AccessToken);

            builder
                .HasMany(user => user.Polls)
                .WithOne(poll => poll.User)
                .OnDelete(DeleteBehavior.Cascade);;
            
            builder.HasIndex(user => user.Login).IsUnique();
            builder.HasIndex(user => user.AccessToken).IsUnique();
        }
    }
}