using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Polling.Attributes.Filters
{
    public class AccessTokenNeedAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // todo: check auth token
            context.Result = new StatusCodeResult(404);
        }
    }
}