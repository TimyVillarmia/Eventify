using System.ComponentModel.DataAnnotations;

namespace Eventify.DataAnnotations
{
    public class CustomDateAttribute : ValidationAttribute
    {
        public const string MINIMUM_DATE_OF_EVENT = "Please select a date in the future.";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var valueString = value != null ? value.ToString() : null;

            if (string.IsNullOrWhiteSpace(valueString))
            {
                // No value, so return success.
                return ValidationResult.Success;
            }

            // Convert to date time.
            if (!DateTime.TryParse(valueString, out DateTime doe))
            {
                // Not a valid date, so return error.
                return new ValidationResult("Unable to convert the date of event to a valid date");
            }

            // Minimum date of event
            var minDateOfEvent = DateTime.Now.Date;

            if (doe < minDateOfEvent)
            {
                // Under minimum date of event, so return error.
                return new ValidationResult(MINIMUM_DATE_OF_EVENT);
            }

            // Return success
            return ValidationResult.Success;
        }

    }
}
