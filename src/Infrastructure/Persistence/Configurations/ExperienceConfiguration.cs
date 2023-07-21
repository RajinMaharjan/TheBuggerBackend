using Excallibur.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Excallibur.Infrastructure.Persistence.Configurations
{
    public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired();
            builder.Property(x => x.TesterId).HasColumnName("tester_id").HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired();
            builder.Property(x => x.ExperienceName).HasColumnName("exeprience_name").HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired();
            builder.Property(x => x.ExperienceYear).HasColumnName("exeprience_year").HasColumnType("INT(2)").HasMaxLength(2).IsRequired();
            builder.Property(x => x.ExperienceMonth).HasColumnName("exeprience_month").HasColumnType("INT(2)").HasMaxLength(2).IsRequired();
            builder.Property(x => x.ExperinceDescription).HasColumnName("exeprience_description").HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired();
            builder.Property(x => x.CreatedBy).HasColumnName("created_by").HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired().HasColumnType("DATETIME").IsRequired();
            builder.Property(x => x.LastModifiedBy).HasColumnName("last_modified_by").HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.LastModifiedAt).HasColumnName("last_modified_at").HasColumnType("DATETIME").IsRequired(false);
        }
    }
}
