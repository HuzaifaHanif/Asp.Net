using System.ComponentModel.DataAnnotations;
using e_CommerceApp.Models;

namespace e_CommerceApp.CustomValidator
{
    public class InvoiceValidator : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value ,ValidationContext validationContext)
        {
            if(value != null)
            {
                var order = (Order)validationContext.ObjectInstance;
                

                if(order.Products != null)
                {
                    double? TotalInvoice = order.Products.Sum(p => p.Price * p.Quantity);
                    
                    if (order.InvoicePrice != TotalInvoice)
                        return new ValidationResult("Invoice Price doesn't match with the total cost of the specified products in the order.");
                }       
            }

            return  ValidationResult.Success;            
        }
    }
}
