using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Polling.Db;

namespace Polling.Controllers
{
    [ApiController]
    public class StatusController : Controller
    {
        private readonly IDbConnectionStatusChecker _connectionStatusChecker;

        public StatusController(IDbConnectionStatusChecker connectionStatusChecker)
        {
            _connectionStatusChecker = connectionStatusChecker;
        }
        
        [HttpGet("status")]
        public ActionResult<Dictionary<string, string>> Index()
        {
            return new Dictionary<string, string>
            {
                {"Database connection", _connectionStatusChecker.IsConnected() ? "connected" : "false"}
            };
        }
    }
}