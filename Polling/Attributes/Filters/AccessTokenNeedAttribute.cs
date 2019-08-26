using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Polling.Entities;
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
            User user;

            try
            {
                user = _userProvider.GetUser(context.HttpContext.Request);
            }
            catch (Exception e)
            {
                user = null;
            }
            
            if (user == null)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}