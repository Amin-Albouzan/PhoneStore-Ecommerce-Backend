using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersService.DTO;
using UsersService.Repositories;

namespace UsersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentRestController : ControllerBase
    {
        private readonly ApplicationDbContext context;


        public PaymentRestController(ApplicationDbContext _context)
        {

            context = _context;
        }




        [HttpGet("GetUserPaymentData")]
        public IActionResult GetUserPaymentData()
        {
        
        List<PaymentView> PaymentView=context.PaymentView.ToList();

            if (PaymentView.Any())
            {
            return Ok(PaymentView);
            }

            else
            {
                return BadRequest();
            }



        }






        [HttpGet("GetShoppingListCount")]
        public IActionResult GetShoppingListCount()
        {

            var count = context.PaymentData
     .Select(p => ApplicationDbContext.ShoppingListCount())
     .FirstOrDefault();
            if (count > 0)
            {
                return Ok(count);
            }

            else
            {
                return BadRequest();
            }


        }


    }
}
