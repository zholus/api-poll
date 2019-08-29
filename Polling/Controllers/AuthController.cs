using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Polling.Builders;
using Polling.Db.UoW;
using Polling.RequestModels;
using Polling.Security;

namespace Polling.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserBuilder _userBuilder;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IPasswordHasher _passwordHasher;

        public AuthController(
            IUnitOfWork unitOfWork,
            IUserBuilder userBuilder, 
            ITokenGenerator tokenGenerator,
            IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _userBuilder = userBuilder;
            _tokenGenerator = tokenGenerator;
            _passwordHasher = passwordHasher;
        }
        
        [HttpPost("login")]
        public ActionResult<IEnumerable<string>> Login([FromForm] LoginRequestModel requestModel)
        {
            var user = _unitOfWork.Users.FindByLogin(requestModel.Login);

            if (_passwordHasher.Verify(requestModel.Password, user))
            {
                user.AccessToken = _tokenGenerator.Generate();

                _unitOfWork.Users.Update(user);

                _unitOfWork.Commit();
                
                return Ok(new {user.AccessToken});
            }
            
            return Unauthorized(new {Message = "Please provider correct credentials"});
        }

        [HttpPost("register")]
        public IActionResult Register([FromForm] RegisterRequestModel requestModel)
        {
            var user = _userBuilder.BuildFrom(requestModel);

            user.AccessToken = _tokenGenerator.Generate();

            _unitOfWork.Users.Add(user);

            _unitOfWork.Commit();
            
            return Ok(new { user.AccessToken });
        }
    }
}