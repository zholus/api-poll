using Polling.Entities;
using Polling.RequestModels;
using Polling.Security;

namespace Polling.Builders
{
    public class UserBuilder : IUserBuilder
    {
        private readonly IPasswordHasher _passwordHasher;

        public UserBuilder(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public User BuildFrom(RegisterRequestModel registerRequestModel)
        {
            return new User(registerRequestModel.Login, _passwordHasher.HashPassword(registerRequestModel.Password));
        }
    }
}