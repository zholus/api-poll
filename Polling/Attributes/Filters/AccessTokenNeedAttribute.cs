using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Polling.Providers;

namespace Polling.Attributes.Filters
{
    public class AccessTokenNeedAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        private readonly IUserProvider _userProvider;

        public AccessTokenNeedAttribute(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (_userProvider.GetUser(context.HttpContext.Request) == null)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}