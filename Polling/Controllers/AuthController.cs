using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Polling.Builders;
using Polling.Entities;
using Polling.Repositories;
using Polling.RequestModels;
using Polling.Security;

namespace Polling.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserBuilder _userBuilder;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthController(IUserRepository userRepository, IUserBuilder userBuilder, ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _userBuilder = userBuilder;
            _tokenGenerator = tokenGenerator;
        }
        
        // GET  
        [HttpGet("test")]
        public ActionResult<IEnumerable<string>> Login()
        {
            return new [] { "test" };
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