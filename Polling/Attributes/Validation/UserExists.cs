using System.ComponentModel.DataAnnotations;
using Polling.Repositories;

namespace Polling.Attributes.Validation
{
    public class UserExists : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var userRepository = GetUserRepository(validationContext);

            var user = userRepository.FindByLogin((string) value);

            return user == null ? new ValidationResult("User does not exists") : null;
        }

        private IUserRepository GetUserRepository(ValidationContext validationContext)
        {
            return (IUserRepository)validationContext.GetService(typeof(IUserRepository));
        }
    }
}