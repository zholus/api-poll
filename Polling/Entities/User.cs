using System.Collections.Generic;

namespace Polling.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; }
        public string Password { get; }
        public string AccessToken { get; set; }
        public IEnumerable<Poll> Polls { get; set; }

        public User(string login, string password, string accessToken = null)
        {
            Login = login;
            Password = password;
            AccessToken = accessToken;
        }
    }
}