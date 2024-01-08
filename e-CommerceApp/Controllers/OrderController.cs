using Microsoft.AspNetCore.Mvc;
using e_CommerceApp.Models;

namespace e_CommerceApp.Controllers
{
    public class OrderController : Controller
    {
        [Route("order")]
        public IActionResult Index(Order order)
        {
            if(!ModelState.IsValid)
            {
                string errors = string.Join("\n",ModelState.Values.SelectMany(value =>
                value.Errors).Select(err => err.ErrorMessage)); 
                
                return BadRequest(errors);
            }


            Random random = new Random();
            order.OrderNo = random.Next(1,100000);
           
            return Json($"Order Number: {order.OrderNo}");
        }
    }
}
