using Microsoft.EntityFrameworkCore;
using Outloud.QuizService.Persistance.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Outloud.QuizService.Persistance.Repositiories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly QuizDbContext context;

        public CategoryRepository(QuizDbContext context)
        {
            this.context = context;
        }

        public async Task<Category> GetCategoryAsync(Guid id) => await context.Categories.Include(x => x.Quizes).SingleOrDefaultAsync(x => x.Id == id);

        public async Task<Category> GetCategoryAsync(string name) => await context.Categories.Include(x => x.Quizes).SingleOrDefaultAsync(x => x.Name == name);

        public async Task<IEnumerable<Category>> GetCategoriesAsync() => await context.Categories.ToListAsync();
    }

    public interface ICategoryRepository
    {
        Task<Category> GetCategoryAsync(Guid id);
        Task<Category> GetCategoryAsync(string name);
        Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}
