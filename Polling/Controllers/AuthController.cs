using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal;
using Microsoft.AspNetCore.Mvc;
using Polling.Builders;
using Polling.Repositories;
using Polling.Security;
using Polling.RequestModels;

namespace Polling.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserBuilder _userBuilder;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IPasswordHasher _passwordHasher;

        public AuthController(
            IUserRepository userRepository, 
            IUserBuilder userBuilder, 
            ITokenGenerator tokenGenerator,
            IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _userBuilder = userBuilder;
            _tokenGenerator = tokenGenerator;
            _passwordHasher = passwordHasher;
        }
        
        // GET  
        [HttpPost("login")]
        public ActionResult<IEnumerable<string>> Login([FromForm] LoginModel model)
        {
            var user = _userRepository.FindByLogin(model.Login);

            if (_passwordHasher.Verify(model.Password, user))
            {
                user.AccessToken = _tokenGenerator.Generate();

                _userRepository.Save(user);

                return Ok(new {user.AccessToken});
            }
            
            return Unauthorized(new {Error = "Please provider correct credentials"});
        }

        [HttpPost("register")]
        public IActionResult Register([FromForm] RegisterModel model)
        {
            var user = _userBuilder.BuildFrom(model);

            user.AccessToken = _tokenGenerator.Generate();
            
            if (_userRepository.Add(user))
            {
                return Ok(new { user.AccessToken });
            }

            return StatusCode(500, new {Error = "Server error"});
        }
    }
}