using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Polling.Entities;

namespace Polling.EntityConfigurations
{
    public class QuestionEntityTypeConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(question => question.Id);

            builder.Property(question => question.Title).IsRequired();

            builder
                .HasOne(question => question.Poll)
                .WithMany(poll => poll.Questions);
                
            builder.HasIndex("Title", "PollId").IsUnique();
        }
    }
}