using Polling.Entities;

namespace Polling.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByLogin(string login);
    }
}