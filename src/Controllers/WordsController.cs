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
    public class WordsController : Controller
    {
        private readonly IQuizRepository quizRepository;
        private readonly IUnitOfWork unitOfWork;

        public WordsController(IQuizRepository quizRepository, IUnitOfWork unitOfWork)
        {
            this.quizRepository = quizRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Add(WordDTO word)
        {
            var entity = Mapper.Map(word);
            await quizRepository.AddWordAsync(word.ParentId, entity);
            await unitOfWork.CompleteAsync();
            return Accepted();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await quizRepository.GetWordsAsync();
            return Ok(items);
        }

        [HttpGet("{parentId}")]
        public async Task<IActionResult> Get(Guid parentId)
        {
            var items = await quizRepository.GetWordsAsync(parentId);
            return Ok(items);
        }
    }
}
