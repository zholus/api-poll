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
                .HasMany(question => question.Answers)
                .WithOne(answer => answer.Question)
                .OnDelete(DeleteBehavior.Cascade);;
            
            builder.HasIndex("Title", "PollId").IsUnique();
        }
    }
}