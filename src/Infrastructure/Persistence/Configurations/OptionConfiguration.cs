using Excallibur.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Excallibur.Infrastructure.Persistence.Configurations
{
    public class OptionConfiguration : IEntityTypeConfiguration<QuizOption>
    {

        public void Configure(EntityTypeBuilder<QuizOption> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired();
            builder.Property(x => x.QuestionId).HasColumnName("question_id").HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("VARCHAR(200)").HasMaxLength(500).IsRequired();
            builder.Property(x => x.IsCorrect).HasColumnName("is_correct").HasDefaultValue(false);
            builder.Property(x => x.CreatedBy).HasColumnName("created_by").HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("created_on").IsRequired().HasColumnType("DATETIME").IsRequired();
            builder.Property(x => x.LastModifiedBy).HasColumnName("last_modified_by").HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.LastModifiedAt).HasColumnName("last_updated_by").HasColumnType("DATETIME").IsRequired(false);
        }

    }
}
