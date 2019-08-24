using System.Linq;
using Microsoft.EntityFrameworkCore;
using Polling.Db;
using Polling.Entities;

namespace Polling.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        
        public UserRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        
        public bool Add(User user)
        {
            _context.Users.Add(user);

            return _context.SaveChanges() > 0;
        }
        
        public User FindByLogin(string login)
        {
            return _context.Users.FirstOrDefault(user => user.Login == login);
        }
    }
}