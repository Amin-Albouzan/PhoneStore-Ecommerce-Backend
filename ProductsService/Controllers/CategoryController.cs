using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsService.DTO;
using ProductsService.Models;
using ProductsService.Repositories;

namespace ProductsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly ApplicationDbContext context;


        public CategoryController(ApplicationDbContext _context)
        {

            context = _context;
        }


        [HttpGet]
        public IActionResult getAllCategories()
        {
            List<Category> categoriesData = context.CategoryData.ToList();

            if (categoriesData != null)
            {
                return Ok(categoriesData);

            }

            else
            {
                return Ok();
            }



        }







        [HttpGet("GetCategoryView")]
        public IActionResult GetCategoryView()
        {
            List<categoryView> categoryView = context.categoryView.ToList();

            if (categoryView.Any())
            {

                return Ok(categoryView);
            }

            else
            {
                return BadRequest();
            }

        }



        [HttpGet("GetCategoriesListCount")]
        public IActionResult GetCategoriesListCount()
        {
            CategoriesListCount categoriesListCount=context.CategoriesListCount.FirstOrDefault();
            
            if(categoriesListCount != null)
            {
                return Ok(categoriesListCount);
            }


            else
            {
                return BadRequest();
            }
        }
















    }
}