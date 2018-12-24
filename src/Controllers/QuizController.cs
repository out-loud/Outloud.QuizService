using Microsoft.AspNetCore.Mvc;
using Outloud.QuizService.DTO;
using Outloud.QuizService.Mappers;
using Outloud.QuizService.Persistance;
using Outloud.QuizService.Persistance.Repositiories;
using System;
using System.Threading.Tasks;

namespace Outloud.QuizService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuizController : Controller
    {
        private readonly IQuizRepository quizRepository;
        private readonly IUnitOfWork unitOfWork;

        public QuizController(IQuizRepository quizRepository, IUnitOfWork unitOfWork)
        {
            this.quizRepository = quizRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await quizRepository.GetQuizesAsync());

        [HttpGet("{parentId}")]
        public async Task<IActionResult> Get(Guid parentId) => Ok(await quizRepository.GetQuizesAsync(parentId));

        [HttpPost]
        public async Task<IActionResult> Add(QuizDTO quiz)
        {
            var entity = Mapper.Map(quiz);
            await quizRepository.AddQuizAsync(quiz.ParentId, entity);
            await unitOfWork.CompleteAsync();
            return Accepted();
        }
    }
}
