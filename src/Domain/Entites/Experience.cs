using Excallibur.Domain.Common;

namespace Excallibur.Domain.Entites
{
    public class Experience : AuditableEntity
    {
        public string ExperienceName { get; set; }
        public int ExperienceYear { get; set; }
        public int ExperienceMonth { get; set; }
        public string ExperinceDescription { get; set; }
        public string TesterId { get; set; }
        public Tester Tester { get; set; }
    }
}
