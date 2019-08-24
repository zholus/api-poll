using Microsoft.AspNetCore.Identity;
using Polling.Entities;

namespace Polling.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        
        public bool Verify(string plainPassword, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, hash);
        }

        public bool Verify(string plainPassword, User user)
        {
            return Verify(plainPassword, user.Password);
        }
    }
}