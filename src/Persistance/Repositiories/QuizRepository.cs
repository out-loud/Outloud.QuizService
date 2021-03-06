﻿using Microsoft.EntityFrameworkCore;
using Outloud.QuizService.Persistance.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Outloud.QuizService.Persistance.Repositiories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly QuizDbContext _context;

        public QuizRepository(QuizDbContext context)
        {
            this._context = context;
        }

        public async Task<QuizEntity> GetQuizAsync(Guid id) => await _context.Quizes.Include(x => x.Words).SingleOrDefaultAsync(x => x.Id == id);

        public async Task<QuizEntity> GetQuizAsync(string name) => await _context.Quizes.Include(x => x.Words).SingleOrDefaultAsync(x => x.Name == name);

        public async Task<ICollection<QuizEntity>> GetQuizesAsync() => await _context.Quizes.Include(x => x.Words).ToListAsync();

        public async Task AddQuizAsync(Guid parentId, QuizEntity entity)
        {
            var category = await _context.Categories.Include(x => x.Quizes).SingleOrDefaultAsync(x => x.Id == parentId);
            category.Quizes.Add(entity);
        }

        public async Task<ICollection<WordEntity>> GetWordsAsync() => await _context.Words.ToListAsync();

        public async Task AddWordAsync(Guid parentId, WordEntity entity)
        {
            var quiz = await _context.Quizes.Include(x => x.Words).SingleOrDefaultAsync(x => x.Id == parentId);
            quiz.Words.Add(entity);
        }

        public async Task<ICollection<WordEntity>> GetWordsAsync(Guid quizId)
        {
            var quiz = await _context.Quizes.Include(x => x.Words).SingleOrDefaultAsync(x => x.Id == quizId);
            return quiz?.Words;
        }

        public async Task<ICollection<QuizEntity>> GetQuizesAsync(Guid categoryId)
        {
            var category = await _context.Categories.Include(x => x.Quizes).ThenInclude(y => y.Words).SingleOrDefaultAsync(x => x.Id == categoryId);
            return category?.Quizes;
        }
  }

    public interface IQuizRepository
    {
        Task<QuizEntity> GetQuizAsync(Guid id);
        Task<QuizEntity> GetQuizAsync(string name);
        Task<ICollection<QuizEntity>> GetQuizesAsync();
        Task<ICollection<QuizEntity>> GetQuizesAsync(Guid categoryId);
        Task AddQuizAsync(Guid parentId, QuizEntity entity);
        Task AddWordAsync(Guid parentId, WordEntity entity);
        Task<ICollection<WordEntity>> GetWordsAsync();
        Task<ICollection<WordEntity>> GetWordsAsync(Guid quizId);
    }
}
