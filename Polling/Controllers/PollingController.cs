using Microsoft.AspNetCore.Mvc;
using Polling.Attributes.Filters;

namespace Polling.Controllers
{
    [ApiController]
    public class PollingController : ControllerBase
    {
        [HttpGet("polling")]
        [AccessTokenNeedAttribute]
        public ActionResult<string> Index()
        {
            return "ok";
        }
    }
}