using Excallibur.Application.Common.Interfaces;
using Excallibur.Application.Common.Models.RequestModel;
using Excallibur.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/quiz")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;
        private readonly UserManager<Tester> _userManager;
        //private readonly ILogger _logger;
        public QuizController(
            IQuizService quizService,
            UserManager<Tester> userManager
            )
        //ILogger logger)
        {
            _quizService = quizService ?? throw new ArgumentNullException(nameof(quizService));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            //_logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }

        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
            //_logger.LogInformation("\n\nFetching Quiz data...\n\n");
            var quiz = await _quizService.GetQuiz();
            return Ok(quiz);
        }

        [HttpPost("submit")]
        public async Task<IActionResult> GetResult(ICollection<QuizResultRequestModel> model)
        {
            var user = await _userManager.GetUserAsync(User);


            return Ok(await _quizService.GetResultAsync(model, user));
        }
    }
}
