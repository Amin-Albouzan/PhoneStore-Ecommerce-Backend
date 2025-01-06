using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersService.DTO;
using UsersService.Repositories;

namespace UsersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class managerController : ControllerBase
    {

        private readonly ApplicationDbContext context;


        public managerController(ApplicationDbContext _context)
        {

            context = _context;
        }







        [HttpPost("LoginTest")]

        public IActionResult LoginTest(LoginDto data)
        {
            var email = context.managerData.FirstOrDefault(e => e.manager_Email == data.Email);
            var password = context.managerData.FirstOrDefault(e => e.manager_Password == data.Password);

            if (email != null && password != null)
            {
                return Ok(data);

            }

            else
            {
                return BadRequest();
            }

        }




    }
}
