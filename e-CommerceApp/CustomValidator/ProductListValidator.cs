using System.ComponentModel.DataAnnotations;
using e_CommerceApp.Models;

namespace e_CommerceApp.CustomValidator
{
    public class ProductListValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                List<Product> products = (List<Product>)value;

                if(products.Count == 0)
                    return new ValidationResult("Order should have at least one product");

                return ValidationResult.Success;

            }

            return null;

        }
    
    }
}
