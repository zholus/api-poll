using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Polling.Controllers
{
    [ApiController]
    [Route("")]
    public class WelcomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Dictionary<string, string>> Index()
        {
            return new Dictionary<string, string>
            {
                {"Application", "polling application"},
                {"Description", "Type your question, select poll options"}
            };
        }
    }
}