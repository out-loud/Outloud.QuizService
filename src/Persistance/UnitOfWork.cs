using System.Threading.Tasks;

namespace Outloud.QuizService.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuizDbContext context;

        public UnitOfWork(QuizDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }

    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
