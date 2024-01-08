using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using e_CommerceApp.CustomValidator;

namespace e_CommerceApp.Models
{
    public class Order
    {
        public int? OrderNo { get; set; }

        [OrderDateValidator]
        [Required(ErrorMessage ="{0} can't be Blank")]
        [Display(Name = "Order Date")]
        public DateTime? OrderDate { get; set; }

        [Required (ErrorMessage = "{0} cannot be Blank")]
        [InvoiceValidator(ErrorMessage = "{0} doesn't match with the total cost of the specified products in the order.")]
        [Display(Name ="Invoice Price")]
        [Range(1, 99999.99, ErrorMessage = "{0} should be a valid number")]
        public double InvoicePrice { get; set; }

        [ProductListValidator]
        public List<Product>? Products { get; set; } = new List<Product>();

        public override string ToString()
        {
            string? productsInfo = "";

            if (Products != null)
            {
                foreach (var product in Products)
                {
                    productsInfo = string.Join("\n", $"Product Price: {product.Price} Product Code: {product.Code} Product Quantity: {product.Quantity}");
                }

            }

            else
                productsInfo = "No Products";
                
            return $"Order oject - order number: {OrderNo} Order Date: {OrderDate} Price: {InvoicePrice} \n Products: \n{productsInfo}";

        }
    }
}
