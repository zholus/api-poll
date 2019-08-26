using Microsoft.AspNetCore.Mvc;
using Polling.Attributes.Filters;
using Polling.Providers;

namespace Polling.Controllers
{
    [ApiController]
    [TypeFilter(typeof(AccessTokenNeedAttribute))]
    public class PollingController : ControllerBase
    {
        private readonly IUserProvider _userProvider;

        public PollingController(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        [HttpPost("polling")]
        public ActionResult<string> Create()
        {
            var user = _userProvider.GetUser(HttpContext.Request);
            
            
            return "ok";
        }
    }
}