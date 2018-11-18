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

        public async Task<IEnumerable<QuizEntity>> GetQuizesAsync() => await context.Quizes.ToListAsync();
    }

    public interface IQuizRepository
    {
        Task<QuizEntity> GetQuizAsync(Guid id);
        Task<QuizEntity> GetQuizAsync(string name);
        Task<IEnumerable<QuizEntity>> GetQuizesAsync();
    }
}
