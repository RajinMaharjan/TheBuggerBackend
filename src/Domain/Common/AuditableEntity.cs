using Domain.Common;

namespace Excallibur.Domain.Common
{
    public class AuditableEntity : IdentifiableEntity
    {

        public DateTime? CreatedAt { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? LastModifiedAt { get; set; }

        public Guid? LastModifiedBy { get; set; }

        public AuditableEntity()
        {

        }
    }
}
