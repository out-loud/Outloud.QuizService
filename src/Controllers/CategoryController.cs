using Microsoft.AspNetCore.Mvc;
using Outloud.QuizService.Dto;
using Outloud.QuizService.Mappers;
using Outloud.QuizService.Persistance;
using Outloud.QuizService.Persistance.Repositiories;
using System;
using System.Threading.Tasks;

namespace Outloud.QuizService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public CategoryController(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }
        
        [HttpGet("all")]
        public async Task<IActionResult> Get() => Ok(await categoryRepository.GetCategoriesAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id) => Ok(await categoryRepository.GetCategoryAsync(id));

        [HttpPost]
        public async Task<IActionResult> Add(CategoryDTO category)
        {
            var entity = Mapper.Map(category);
            await categoryRepository.AddCategoryAsync(entity);
            await unitOfWork.CompleteAsync();
            return Accepted();
        }
    }
}
