using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Polling.Db.UoW;
using Polling.Entities;
using Polling.Providers;

namespace Polling.Attributes.Validation
{
    public class UniquePollTitle : ValidationAttribute
    {
        private IUnitOfWork UnitOfWork { get; set; }
        private IUserProvider UserProvider { get; set; }
        private HttpContext HttpContext { get; set; }
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            SetUpServices(validationContext);

            var user = GetUser();
            
            var title = (string) value;

            var poll = UnitOfWork.Polls.FindByUserAndTitle(user, title);
            
            return poll != null ? new ValidationResult("Poll with same title already exists") : null;
        }

        private void SetUpServices(ValidationContext validationContext)
        {
            UnitOfWork = (IUnitOfWork)validationContext.GetService(typeof(IUnitOfWork));
            UserProvider = (IUserProvider)validationContext.GetService(typeof(IUserProvider));
            HttpContext = ((IHttpContextAccessor)validationContext.GetService(typeof(IHttpContextAccessor))).HttpContext;
        }

        private User GetUser()
        {
            return UserProvider.GetUser(HttpContext.Request);
        }
    }
}