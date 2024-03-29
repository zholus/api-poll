using Polling.Entities;

namespace Polling.Repositories
{
    public interface IPollRepository : IRepository<Poll>
    {
        Poll FindByUserAndTitle(User user, string title);
        Poll FindByUserAndId(User user, int pollId);
    }
}