using System.Linq;
using Microsoft.EntityFrameworkCore;
using Polling.Db;
using Polling.Entities;

namespace Polling.Repositories
{
    public class PollRepository : Repository<Poll>, IPollRepository
    {
        public PollRepository(ApplicationDbContext context) : base(context)
        {
        }
        
        public Poll FindByUserAndTitle(User user, string title)
        {
            return Context.Polls.FirstOrDefault(poll => poll.User.Equals(user) && poll.Title.Equals(title));
        }

        public Poll FF(int pollId)
        {
            return Context.Polls.FirstOrDefault(poll => poll.Id == pollId);
        }
    }
}