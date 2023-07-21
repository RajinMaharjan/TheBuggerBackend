using Excallibur.Application.Common.Models.RequestModel;
using Excallibur.Application.Common.Models.ResponseModel;
using Excallibur.Domain.Entites;

namespace Excallibur.Application.Common.Interfaces
{
    public interface IQuizService
    {
        public Task<ICollection<QuestionResponseModel>> GetQuiz();

        public Task<QuizResultResponseModel> GetResultAsync(ICollection<QuizResultRequestModel> model, Tester tester);
    }
}
