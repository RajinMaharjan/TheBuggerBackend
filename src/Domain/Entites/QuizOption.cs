using Excallibur.Domain.Common;

namespace Excallibur.Domain.Entites
{
    public class QuizOption : AuditableEntity
    {
        public Guid QuestionId { get; set; }
        public string Name { get; set; }
        public bool IsCorrect { get; set; }

        public QuizQuestion Question { get; set; }
    }
}
