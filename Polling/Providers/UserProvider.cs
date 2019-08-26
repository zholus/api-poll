using System;
using Microsoft.AspNetCore.Http;
using Polling.Db.UoW;
using Polling.Entities;

namespace Polling.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserProvider(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User GetUser(HttpRequest request)
        {
            var token = request.Headers["Authorization"].ToString();
            
            var user = _unitOfWork.Users.FindByToken(token);

            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            return user;
        }
    }
}