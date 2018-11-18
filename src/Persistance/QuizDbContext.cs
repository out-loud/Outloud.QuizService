using Microsoft.EntityFrameworkCore;
using Outloud.QuizService.Persistance.Models;

namespace Outloud.QuizService.Persistance
{
    public class QuizDbContext : DbContext
    {
        public DbSet<Word> Words { get; set; }
        public DbSet<Quiz> Quizes { get; set; }
        public DbSet<Category> Categories { get; set; }
        
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
        {
        }
    }
}