using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Polling.Attributes.Validation
{
    public class UniqueEnumerableValue : ValidationAttribute
    {
        private readonly string _propertyName;
        
        public UniqueEnumerableValue(string propertyName)
        {
            _propertyName = propertyName;
        }
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var list = new List<object>();
            var values = (IEnumerable<object>)value;

            foreach (var obj in values)
            {
                var val = obj.GetType().GetProperty(_propertyName).GetValue(obj, null);

                if (list.Contains(val))
                {
                    return new ValidationResult("Values of list are not unique");
                }
                
                list.Add(val);
            }

            return null;
        }
    }
}