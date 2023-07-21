using Excallibur.Domain.Common;

namespace Excallibur.Domain.Entites
{
    public class QuizQuestion : AuditableEntity
    {
        public string Name { get; set; }
        public bool IsDelete { get; set; } = false;
        public ICollection<QuizOption> Options { get; set; } = new List<QuizOption>();

    }
}
