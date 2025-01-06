using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersService.DTO;
using UsersService.Models;
using UsersService.Repositories;

namespace UsersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private readonly ApplicationDbContext context;


        public CartController(ApplicationDbContext _context)
        {

            context = _context;
        }


        //Stored Procedure


        [HttpPost("GetCartSummary")]
        public IActionResult GetCartSummary([FromBody] emailRequest emailRequest)
        {

            UserData userData = context.UserData.FirstOrDefault(e => e.User_Email == emailRequest.Email);



            var result = context.GetCartSummary(userData.User_ID);

            // التحقق من النتيجة
            if (result == null || !result.Any())
            {
                return BadRequest();
            }

            return Ok(result); // أو return Ok(result);
        }




        [HttpPost("GetTotalPrice")]
        public IActionResult GetTotalPrice([FromBody] emailRequest emailRequest)
        {

            UserData userData = context.UserData.FirstOrDefault(e => e.User_Email == emailRequest.Email);



            var totalPrice = context.GetTotalPrice(userData.User_ID);

            return Ok(totalPrice); // أو return Ok(result);
        }











        [HttpPost("getCartFromUserEmail")]
        public IActionResult GetAllCarts([FromBody] emailRequest emailRequest) {



            UserData userData = context.UserData.FirstOrDefault(e => e.User_Email == emailRequest.Email);

            List<CartData> cartData = context.CartData.Where(e => e.User_ID == userData.User_ID).ToList();



            if (cartData.Any())
            {
                return Ok(cartData);
            }
            else
            {
                return BadRequest();
            }

        }





        [HttpPost("getShoppingList")]
        public IActionResult getShoppingList([FromBody] emailRequest emailRequest)
        {



            UserData userData = context.UserData.FirstOrDefault(e => e.User_Email == emailRequest.Email);
            List<ShoppingListSP> ShoppingListSP = context.GetShoppingListSP(userData.User_ID);


            if (ShoppingListSP.Any())
            {
                return Ok(ShoppingListSP);
            }

            else
            {
                return BadRequest();
            }


        }
















        [HttpDelete("{id:int}")]
        public IActionResult DeleteCartFromId(int id)
        {


            CartData cart = context.CartData.FirstOrDefault(c => c.Cart_ID == id);

            if (cart.Quantity == 1)
            {
                context.CartData.Remove(cart);
                context.SaveChanges();
                return Ok();
            }

            else
            {
                cart.Quantity--;
                context.SaveChanges();
                return Ok();
            }


        }







        [HttpPost]
        public IActionResult AddProductToCart(CartDTO cartDTO)
        {
            UserData userData=context.UserData.FirstOrDefault(e => e.User_Email == cartDTO.UserEmail);

           
            CartData cartData = context.CartData
    .Where(e => e.User_ID == userData.User_ID && e.Product_ID == cartDTO.productID)
    .FirstOrDefault();

            if (cartData != null) 
            {
                cartData.Quantity++;
            context.SaveChanges();
                return Ok();

            }
            else
            {
                cartData = new CartData
                {
                    User_ID = userData.User_ID,
                    Product_ID = cartDTO.productID,
                    Quantity = 1,
                    Product_Name= cartDTO.Product_Name,
                    Product_Discription= cartDTO.Product_Discription,
                    Product_ImageUrl= cartDTO.Product_ImageUrl,
                    Product_Price= cartDTO.Product_Price
                };
                context.CartData.Add(cartData);
                context.SaveChanges();
                return Ok();
            }



        }




        [HttpDelete("DeleteAllProductFromCart")]
        public IActionResult DeleteAllProductFromCart([FromBody] emailRequest emailRequest ) 
        {
            UserData userData = context.UserData.FirstOrDefault(e => e.User_Email == emailRequest.Email);

            List<CartData> cartData =context.CartData.Where(e=>e.User_ID==userData.User_ID).ToList();

            foreach (var item in cartData)
            {
            
            context.CartData.Remove(item);
                context.SaveChanges();
            }

            return Ok();
        }

        



    }
}
