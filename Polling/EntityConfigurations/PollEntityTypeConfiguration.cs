using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Polling.Entities;

namespace Polling.EntityConfigurations
{
    public class PollEntityTypeConfiguration : IEntityTypeConfiguration<Poll>
    {
        public void Configure(EntityTypeBuilder<Poll> builder)
        {
            builder.HasKey(poll => poll.Id);
            
            builder.Property(poll => poll.Title).IsRequired();

            builder
                .HasOne(poll => poll.User)
                .WithMany(user => user.Polls);

            builder.HasIndex("UserId", "Title").IsUnique();
        }
    }
}