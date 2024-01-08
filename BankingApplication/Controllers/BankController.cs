using Microsoft.AspNetCore.Mvc;
using BankingApplication.Models;

namespace BankingApplication.Controllers
{
    public class BankController : Controller
    {
        Account account = new Account() { accountNo = 1001, accountHolderName = "Huzaifa", currentBalance = 5000 };

        [Route("/")]
        public IActionResult Home()
        {
            if (Request.Method == "GET")
            {
                return Content("Welcome to the Best Bank", "text/plain");
            }

            return BadRequest("Invalid request method");
        }

        [Route("/account-details")]
        public IActionResult AccountDetails()
        {
            if (Request.Method == "GET")
            {
                return Json(account);
            }

            return BadRequest("Invalid request method");
        }

        [Route("/account-statement")]

        public IActionResult AccountStatement()
        {
            if (Request.Method == "GET")
            {
                return File("/feeChallan.pdf", "applictaion/pdf");
            }

            return BadRequest("Invalid request method");
        }

        [Route("/get-current-balance/{accountNumber:int?}")]
        public IActionResult GetCurrentBalance()
        {
            if (Request.Method == "GET")
            {
                int accountNumber = Convert.ToInt32(Request.RouteValues["accountNumber"]);


                if(!Request.RouteValues.ContainsKey("accountNumber"))
                {
                    return BadRequest("Account Number Should Be supplied");
                }


                if (accountNumber == account.accountNo)
                {
                    return Content(account.currentBalance.ToString(), "text/plain");
                }

                else
                    return NotFound("Account Number should be 1001");

            }

            return BadRequest("Invalid request method");

        }


    }
}
