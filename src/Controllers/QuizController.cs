using Microsoft.AspNetCore.Mvc;
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

        public QuizController(IQuizRepository quizRepository)
        {
            this.quizRepository = quizRepository;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get() => Ok(await quizRepository.GetQuizesAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) => Ok(await quizRepository.GetQuizAsync(id));
    }
}
