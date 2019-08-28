using System.Collections.Generic;

namespace Polling.Entities
{
    public class User
    {
        public int Id { get; set; }
        public virtual string Login { get; }
        public virtual string Password { get; }
        public virtual string AccessToken { get; set; }
        public virtual IEnumerable<Poll> Polls { get; set; }

        public User(string login, string password, string accessToken = null)
        {
            Login = login;
            Password = password;
            AccessToken = accessToken;
        }
    }
}