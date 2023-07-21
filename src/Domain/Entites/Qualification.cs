using Excallibur.Domain.Common;

namespace Excallibur.Domain.Entites
{
    public class Qualification : AuditableEntity
    {
        public string QualificationType { get; set; }
        public string QualificationOrganization { get; set; }
        public string QualificationCourse { get; set; }
        public string QualificationSpecialization { get; set; }
        public DateOnly QualificationStartDate { get; set; }
        public DateOnly QualificationEndDate { get; set; }
        public string TesterId { get; set; }
        public Tester Tester { get; set; }
    }
}
