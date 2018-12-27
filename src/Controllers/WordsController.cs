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
        private readonly IQuizRepository _quizRepository;
        private readonly IUnitOfWork _unitOfWork;

        public WordsController(IQuizRepository quizRepository, IUnitOfWork unitOfWork)
        {
            this._quizRepository = quizRepository;
            this._unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Add(WordDTO word)
        {
            var entity = Mapper.Map(word);
            await _quizRepository.AddWordAsync(word.ParentId, entity);
            await _unitOfWork.CompleteAsync();
            return Accepted();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _quizRepository.GetWordsAsync();
            return Ok(items);
        }

        [HttpGet("{parentId}")]
        public async Task<IActionResult> Get(Guid parentId)
        {
            var items = await _quizRepository.GetWordsAsync(parentId);
            return Ok(items);
        }
    }
}
