using Polling.Entities;

namespace Polling.Repositories
{
    public interface IUserRepository
    {
        bool Add(User user);
        User FindByLogin(string login);
        bool Save(User user);
    }
}