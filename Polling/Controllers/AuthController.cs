using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Polling.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        // GET  
        [HttpGet("test")]
        public ActionResult<IEnumerable<string>> Login()
        {
            return new [] { "test" };
        }
    }
}