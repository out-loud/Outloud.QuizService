using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace Outloud.QuizService.Persistance
{
    public class QuizDbContextFactory : IDesignTimeDbContextFactory<QuizDbContext>
    {
        public QuizDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<QuizDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=master;User=sa;Password=1qazxsW@;");

            return new QuizDbContext(optionsBuilder.Options);
        }
    }
}
