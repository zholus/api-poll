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
        public ActionResult<IEnumerable<string>> Login([FromForm] LoginModel model)
        {
            var user = _unitOfWork.Users.FindByLogin(model.Login);

            if (_passwordHasher.Verify(model.Password, user))
            {
                user.AccessToken = _tokenGenerator.Generate();

                _unitOfWork.Users.Update(user);

                _unitOfWork.Commit();
                
                return Ok(new {user.AccessToken});
            }
            
            return Unauthorized(new {Error = "Please provider correct credentials"});
        }

        [HttpPost("register")]
        public IActionResult Register([FromForm] RegisterModel model)
        {
            var user = _userBuilder.BuildFrom(model);

            user.AccessToken = _tokenGenerator.Generate();

            _unitOfWork.Users.Add(user);

            _unitOfWork.Commit();
            
            return Ok(new { user.AccessToken });
        }
    }
}