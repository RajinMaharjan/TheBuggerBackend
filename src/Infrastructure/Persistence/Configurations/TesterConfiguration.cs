using Excallibur.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Excallibur.Infrastructure.Persistence.Configurations
{
    public class TesterConfiguration : IEntityTypeConfiguration<Tester>
    {
        public void Configure(EntityTypeBuilder<Tester> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired();
            builder.Property(x => x.FirstName).HasColumnName("first_name").HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired();
            builder.Property(x => x.LastName).HasColumnName("last_name").HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).HasColumnName("email").HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired();
            builder.Property(x => x.PhoneNumber).HasColumnName("phone_number").HasColumnType("VARCHAR(10)").IsFixedLength().IsRequired();
            builder.Property(x => x.hasPassedQuiz).HasColumnName("has_passed_quiz").HasDefaultValue(false);
            builder.Property(x => x.hasPassedSampleTest).HasColumnName("has_passed_sample_test").HasDefaultValue(false);
            builder.Property(x => x.ImageUrl).HasColumnName("image_url").HasColumnType("VARCHAR(100)").HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.Address).HasColumnName("address").HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.NationalId).HasColumnName("national_id").HasColumnType("VARCHAR(50)").HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.FacebookUrl).HasColumnName("facebook_url").HasColumnType("VARCHAR(100)").HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.InstagramUrl).HasColumnName("instagram_url").HasColumnType("VARCHAR(100)").HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.LinkedInUrl).HasColumnName("linkedin_url").HasColumnType("VARCHAR(100)").HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.TwitterUrl).HasColumnName("twitter_url").HasColumnType("VARCHAR(100)").HasMaxLength(100).IsRequired(false);
            builder.Property(x => x.YoutubeUrl).HasColumnName("youtube_url").HasColumnType("VARCHAR(100)").HasMaxLength(100).IsRequired(false);
            builder.HasMany(x => x.Devices).WithOne(x => x.Tester).HasForeignKey(x => x.TesterId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Qualifications).WithOne(x => x.Tester).HasForeignKey(x => x.TesterId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Experiences).WithOne(x => x.Tester).HasForeignKey(x => x.TesterId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
