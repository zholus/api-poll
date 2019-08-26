using System.Linq;
using Microsoft.EntityFrameworkCore;
using Polling.Db;
using Polling.Entities;

namespace Polling.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        
        public User FindByLogin(string login)
        {
            return FindOne(user => user.Login.Equals(login));
        }

        public User FindByToken(string accessToken)
        {
            return FindOne(user => user.AccessToken.Equals(accessToken));
        }
    }
}