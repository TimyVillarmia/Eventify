using System.ComponentModel.DataAnnotations;

namespace Eventify.DataAnnotations
{
    public class CustomDateAttribute : ValidationAttribute
    {
        public CustomDateAttribute() { }

        public string GetErrorMessage() => "Please select a date in the future.";

        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            var date = (DateTime)value;

            if (DateTime.Compare(date, DateTime.Now) < 0) return new ValidationResult(GetErrorMessage());
            else return ValidationResult.Success;
        }


    }
}
