using System.ComponentModel.DataAnnotations;

namespace e_CommerceApp.Models
{
    public class Product
    {
        [Required(ErrorMessage = "{0} can't be Blank")]
        [Display(Name = "Product Code")]
        [Range(1, 999, ErrorMessage = "{0} should be a valid number")]
        public int? Code { get; set; }

        [Required(ErrorMessage = "{0} can't be Blank")]
        [Display(Name = "Product Price")]
        [Range(1, 999.99, ErrorMessage = "{0} should be a valid number")]
        public double? Price { get; set; }

        [Required(ErrorMessage = "{0} can't be Blank")]
        [Display(Name = "Product Quantity")]
        [Range(1, 99, ErrorMessage = "{0} should be a valid number")]
        public int? Quantity { get; set; }

    }
}
