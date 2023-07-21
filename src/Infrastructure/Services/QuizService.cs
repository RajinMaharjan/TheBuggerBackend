using Application.Common.Models.ResponseModel;
using Excallibur.Application.Common.Exceptions;
using Excallibur.Application.Common.Interfaces;
using Excallibur.Application.Common.Models.RequestModel;
using Excallibur.Application.Common.Models.ResponseModel;
using Excallibur.Domain.Entites;
using Infrastructure.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Excallibur.Infrastructure.Services
{
    public class QuizService : IQuizService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Tester> _userManager;
        public QuizService(IUnitOfWork unitOfWork,
            UserManager<Tester> userManager)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }
        public async Task<ICollection<QuestionResponseModel>> GetQuiz()
        {
            try
            {
                var result = await _unitOfWork.GetRepository<QuizQuestion>()
               .GetAll()
               .Include(q => q.Options)
               .Where(q => !q.IsDelete)
               .OrderBy(q => EF.Functions.Random())
               .Take(20)
               .Select(q => new QuestionResponseModel
               {
                   Name = q.Name,
                   Id = q.Id,
                   CreatedAt = q.CreatedAt,
                   CreatedBy = q.CreatedBy,
                   LastModifiedAt = q.LastModifiedAt,
                   LastModifiedBy = q.LastModifiedBy,
                   Options = q.Options.Select(o => new OptionResponseModel
                   {
                       QuestionId = o.QuestionId,
                       Name = o.Name,
                       Id = o.Id,
                       CreatedAt = o.CreatedAt,
                       CreatedBy = o.CreatedBy,
                       LastModifiedAt = o.LastModifiedAt,
                       LastModifiedBy = o.LastModifiedBy

                   })
                   .OrderBy(q => EF.Functions.Random())
                   .ToList(),
               }).ToListAsync();

                if (result == null)
                {
                    throw new ServiceException("Failed to fetch data, Try again later.");
                }

                return result;
            }
            catch (ServiceException ex)
            {
                throw new ServiceException(ex.Message);
            }
        }

        public async Task<QuizResultResponseModel> GetResultAsync(ICollection<QuizResultRequestModel> model, Tester tester)
        {
            try
            {
                int correct = 0;
                int incorrect = 0;
                foreach (var item in model)
                {
                    var result = await _unitOfWork.GetRepository<QuizOption>()
                        .GetFirstOrDefaultAsync(
                        predicate: p => p.QuestionId == item.QuestionId && p.Id == item.OptionId,
                        selector: s => s.IsCorrect
                        );

                    if (result)
                    {
                        correct++;
                    }
                    else
                    {
                        incorrect++;
                    }
                }
                if (correct == 0 && incorrect == 0)
                {
                    throw new ServiceException("Failed to check result.");
                }
                if (correct >= 16)
                {
                    tester.hasPassedQuiz = true;
                    await _userManager.UpdateAsync(tester);

                    return new QuizResultResponseModel
                    {
                        Correct = correct,
                        Incorrect = incorrect,
                        Marks = correct * 5,
                        Status = "Passed",
                        Message = "Congratulations, you have passed."
                    };
                }
                return new QuizResultResponseModel
                {
                    Correct = correct,
                    Incorrect = incorrect,
                    Marks = correct * 5,
                    Status = "Failed",
                    Message = "Sorry, try again later after a week",

                };
            }
            catch (ServiceException ex)
            {
                throw new ServiceException(ex.Message);
            }
        }
    }
}
