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
    public class QuizesController : Controller
    {
        private readonly IQuizRepository _quizRepository;
        private readonly IUnitOfWork _unitOfWork;

        public QuizesController(IQuizRepository quizRepository, IUnitOfWork unitOfWork)
        {
            this._quizRepository = quizRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _quizRepository.GetQuizesAsync());

        [HttpGet("{parentId}")]
        public async Task<IActionResult> Get(Guid parentId) => Ok(await _quizRepository.GetQuizesAsync(parentId));

        [HttpPost]
        public async Task<IActionResult> Add(QuizDTO quiz)
        {
            var entity = Mapper.Map(quiz);
            await _quizRepository.AddQuizAsync(quiz.ParentId, entity);
            await _unitOfWork.CompleteAsync();
            return Accepted();
        }
    }
}
