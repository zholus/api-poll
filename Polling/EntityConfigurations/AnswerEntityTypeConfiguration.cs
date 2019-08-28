using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Polling.Entities;

namespace Polling.EntityConfigurations
{
    public class AnswerEntityTypeConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(answer => answer.Id);

            builder.Property(answer => answer.Ip).IsRequired();

            builder
                .HasOne(answer => answer.Question)
                .WithMany(question => question.Answers);

            builder.HasIndex("Ip", "PollId").IsUnique();
        }
    }
}