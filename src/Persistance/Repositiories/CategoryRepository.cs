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

        public async Task<CategoryEntity> GetCategoryAsync(Guid id) => await context.Categories.Include(x => x.Quizes).SingleOrDefaultAsync(x => x.Id == id);

        public async Task<CategoryEntity> GetCategoryAsync(string name) => await context.Categories.Include(x => x.Quizes).SingleOrDefaultAsync(x => x.Name == name);

        public async Task<IEnumerable<CategoryEntity>> GetCategoriesAsync() => await context.Categories.Include(x => x.Quizes).ToListAsync();

        public async Task AddCategoryAsync(CategoryEntity entity) => await context.AddAsync(entity);
    }

    public interface ICategoryRepository
    {
        Task<CategoryEntity> GetCategoryAsync(Guid id);
        Task<CategoryEntity> GetCategoryAsync(string name);
        Task<IEnumerable<CategoryEntity>> GetCategoriesAsync();
        Task AddCategoryAsync(CategoryEntity entity);
    }
}
