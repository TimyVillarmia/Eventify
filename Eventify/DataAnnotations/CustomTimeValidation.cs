using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Eventify.DataAnnotations
{
    public class CustomTimeValidation : ValidationAttribute
    {
        private string _startTimePropertyName { get; set; }

        public CustomTimeValidation(string startTimePropertyName)
        {
            _startTimePropertyName = startTimePropertyName;
        }

        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            var startTimeProperty = validationContext.ObjectType.GetProperty(_startTimePropertyName);
            var startTimeValue = startTimeProperty.GetValue(validationContext.ObjectInstance, null);

            if (startTimeValue == null || !(value is TimeOnly))
            {
                // Handle unexpected data types and errors as needed
                return new ValidationResult("Invalid start or end time.");
            }

            TimeOnly startTime = (TimeOnly)startTimeValue;
            TimeOnly endTime = (TimeOnly)value;

            if (endTime <= startTime)
            {
                return new ValidationResult("Event end time must be after event start time.");
            }

            return ValidationResult.Success;
        }
    }
}

