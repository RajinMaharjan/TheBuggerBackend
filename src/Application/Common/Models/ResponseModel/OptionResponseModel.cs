using Excallibur.Domain.Common;

namespace Application.Common.Models.ResponseModel
{
    public class OptionResponseModel : AuditableEntity
    {
        public Guid QuestionId { get; set; }
        public string Name { get; set; }

    }
}
