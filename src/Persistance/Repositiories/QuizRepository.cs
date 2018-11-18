using Microsoft.EntityFrameworkCore;
using Outloud.QuizService.Persistance.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Outloud.QuizService.Persistance.Repositiories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly QuizDbContext context;

        public QuizRepository(QuizDbContext context)
        {
            this.context = context;
        }

        public async Task<QuizEntity> GetQuizAsync(Guid id) => await context.Quizes.Include(x => x.Words).SingleOrDefaultAsync(x => x.Id == id);

        public async Task<QuizEntity> GetQuizAsync(string name) => await context.Quizes.Include(x => x.Words).SingleOrDefaultAsync(x => x.Name == name);

        public async Task<ICollection<QuizEntity>> GetQuizesAsync() => await context.Quizes.Include(x => x.Words).ToListAsync();

        public async Task AddQuizAsync(QuizEntity entity)
        {
            var category = await context.Categories.FindAsync(entity.CategoryId);
            category.Quizes.Add(entity);
        }

        public async Task AddWordAsync(WordEntity entity)
        {
            var quiz = await context.Quizes.FindAsync(entity.QuizId);
            quiz.Words.Add(entity);
        }
    }

    public interface IQuizRepository
    {
        Task<QuizEntity> GetQuizAsync(Guid id);
        Task<QuizEntity> GetQuizAsync(string name);
        Task<ICollection<QuizEntity>> GetQuizesAsync();
        Task AddQuizAsync(QuizEntity entity);
        Task AddWordAsync(WordEntity entity);
    }
}
