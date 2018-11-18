using Microsoft.EntityFrameworkCore;
using Outloud.QuizService.Persistance.Models;

namespace Outloud.QuizService.Persistance
{
    public class QuizDbContext : DbContext
    {
        public DbSet<WordEntity> Words { get; set; }
        public DbSet<QuizEntity> Quizes { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
        {
        }
    }
}