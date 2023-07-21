using Excallibur.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Excallibur.Infrastructure.Persistence.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<QuizQuestion>
    {
        public void Configure(EntityTypeBuilder<QuizQuestion> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Name).HasColumnName("name").HasColumnType("VARCHAR(200)").HasMaxLength(500).IsRequired();
            builder.Property(x => x.IsDelete).HasColumnName("is_delete").HasDefaultValue(false);
            builder.Property(x => x.CreatedBy).HasColumnName("created_by").HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("created_on").IsRequired().HasColumnType("DATETIME").IsRequired();
            builder.Property(x => x.LastModifiedBy).HasColumnName("last_modified_by").HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.LastModifiedAt).HasColumnName("last_updated_by").HasColumnType("DATETIME").IsRequired(false);
            builder.HasMany(x => x.Options).WithOne(x => x.Question).HasForeignKey(x => x.QuestionId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
