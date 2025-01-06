using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsService.Models;
using ProductsService.Repositories;

namespace ProductsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ApplicationDbContext context;


        public ProductController(ApplicationDbContext _context)
        {

            context = _context;
        }



        [HttpGet]
        public ActionResult GetAllProducts()
        {
            List<Product> productsData=context.ProductData.ToList();
            if (productsData != null) {
            return Ok(productsData);
            
            }

            else
            {
                return Ok();
            }



        }


        [HttpGet("getProductFromProductId/{id:int}")]
        public ActionResult getProductFromProductId(int id)
        {
            Product products = context.ProductData.FirstOrDefault(e => e.Product_ID == id);
                return Ok(products);

            



        }





        [HttpGet("{id:int}")]
        public ActionResult getProductFromCategoryId(int id)
        {
            List<Product> products = context.ProductData.Where(e => e.Category_Id == id).ToList();
            if (products != null)
            {
                return Ok(products);

            }

            else
            {
                return Ok();
            }



        }









        [HttpPost]
        public ActionResult CreateNewProduct(Product product)
        {
            Product data = context.ProductData.FirstOrDefault(e => e.Product_Name == product.Product_Name);

            if(data != null)
            {
                return BadRequest();

            }

            else
            {
  context.ProductData.Add(product);
            context.SaveChanges();
                return StatusCode(StatusCodes.Status204NoContent);


            }




        }






        [HttpDelete("{id:int}")]
        public ActionResult DeleteProductFromId(int id)
        {


            Product product = context.ProductData.FirstOrDefault(p => p.Product_ID == id);

            if (product == null)
            {
                return NotFound();  // إذا لم يكن المنتج موجودًا، أرجع حالة 404
            }
            context.ProductData.Remove(product);
            context.SaveChanges();
            return StatusCode(StatusCodes.Status204NoContent);



        }


        [HttpPut("{id:int}")]
        public IActionResult PutProduct(int id,Product product)
        {
            Product Oldproduct = context.ProductData.FirstOrDefault(p => p.Product_ID == id);
            Oldproduct.Product_Name= product.Product_Name;
            Oldproduct.Product_Price = product.Product_Price;
            Oldproduct.Product_Discription = product.Product_Discription;
            Oldproduct.Product_ImageUrl = product.Product_ImageUrl;
            Oldproduct.Category_Id=product.Category_Id;
            context.SaveChanges();
            return StatusCode(StatusCodes.Status204NoContent);
        }




    }
}
