using Microsoft.AspNetCore.Mvc;
using Outloud.QuizService.Persistance;
using Outloud.QuizService.Persistance.Models;
using Outloud.QuizService.Persistance.Repositiories;
using System.Collections.Generic;

namespace Outloud.QuizService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthcheckController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HealthcheckController(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }

        [HttpPut]
        public ActionResult Seed()
        {
            SeedDatabase();
            return Ok();
        }

        private void SeedDatabase()
        {
            var categories = new List<CategoryEntity>
            {
                new CategoryEntity{
                    Name = "Programming",
                    Quizes = new List<QuizEntity>
                    {
                        new QuizEntity
                        {
                            Name = "Basic",
                            Words = new List<WordEntity>
                            {
                                new WordEntity
                                {
                                    Name = "Spreadsheet"
                                },
                                new WordEntity
                                {
                                    Name = "Excel"
                                }
                            }
                        },
                        new QuizEntity
                        {
                            Name = "Intermediate",
                            Words = new List<WordEntity>
                            {

                            }
                        },
                        new QuizEntity
                        {
                            Name = "Advanced",
                            Words = new List<WordEntity>
                            {

                            }
                        }
                    }
                },
                new CategoryEntity("Office"),
                new CategoryEntity("Graphics")
            };

            foreach (var item in categories)
                _categoryRepository.AddCategoryAsync(item);
            _unitOfWork.CompleteAsync();
        }
    }
}
