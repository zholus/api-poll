using System;
using System.ComponentModel.DataAnnotations;
using Polling.Attributes.Validation;

namespace Polling.RequestModels
{
    public class RegisterModel
    {
        [Required]
        [UserExists]
        public string Login { get; set; }
 
        [Required]
        [MinLength(6)]
        [MaxLength(32)]
        public string Password { get; set; }
    }
}