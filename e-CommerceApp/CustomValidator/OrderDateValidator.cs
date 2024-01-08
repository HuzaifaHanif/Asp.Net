using e_CommerceApp.Models;
using System.ComponentModel.DataAnnotations;

namespace e_CommerceApp.CustomValidator
{
    public class OrderDateValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime date = (DateTime)value;

                if(date.Year < 2000)
                {
                    return new ValidationResult("Order date should be greater than or equal to 2000-01-01.");
                }

            }

            return ValidationResult.Success;
        }
    }
}
