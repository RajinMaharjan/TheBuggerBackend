using Excallibur.Domain.Entites;
using Excallibur.Infrastructure.Persistence.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Excallibur.Infrastructure.Persistence
{
    public class QaLintDbContext : IdentityDbContext<Tester>
    {
        public QaLintDbContext(DbContextOptions<QaLintDbContext> options) : base(options) { }
        //public DbSet<Tester> Testers { get; set; }
        public DbSet<Device> DeviceSpecifications { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<QuizQuestion> Question { get; set; }
        public DbSet<QuizOption> Option { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configuring column name in database
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
            SeedRoles(modelBuilder);
            //SeedQuiz(modelBuilder);
            SeedQuiz.SeedQuestionOption(modelBuilder);

        }
        private static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(

                new IdentityRole()
                {
                    Name = "Admin",
                    ConcurrencyStamp = "1",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole()
                {
                    Name = "Tester",
                    ConcurrencyStamp = "2",
                    NormalizedName = "TESTER"
                }

                );

        }
    }
}
