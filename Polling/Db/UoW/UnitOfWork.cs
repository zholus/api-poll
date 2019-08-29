using Polling.Repositories;

namespace Polling.Db.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public IUserRepository Users { get; }
        public IPollRepository Polls { get; }
        public IAnswerRepository Answers { get; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            
            Users = new UserRepository(dbContext);
            Polls = new PollRepository(dbContext);
            Answers = new AnswerRepository(dbContext);
        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }
        
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}