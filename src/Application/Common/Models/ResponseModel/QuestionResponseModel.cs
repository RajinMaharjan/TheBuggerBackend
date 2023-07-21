using Application.Common.Models.ResponseModel;
using Excallibur.Domain.Common;

namespace Excallibur.Application.Common.Models.ResponseModel
{
    public class QuestionResponseModel : AuditableEntity
    {
        public string Name { get; set; }
        public ICollection<OptionResponseModel> Options { get; set; } = new List<OptionResponseModel>();

    }
}
