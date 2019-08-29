using Polling.Db;
using Polling.Entities;

namespace Polling.Repositories
{
    public class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
        public AnswerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}