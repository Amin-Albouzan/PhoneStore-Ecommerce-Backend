using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersService.DTO;
using UsersService.Models;
using UsersService.Repositories;

namespace UsersService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {

        private readonly ApplicationDbContext context;


        public UserDataController(ApplicationDbContext _context)
        {

            context = _context;
        }


        [HttpGet("GetAllUserData")]
        public IActionResult GetAllUserData()
        {
            List<UserDataView> User_Data = context.UserDataView.ToList();
            if(User_Data.Any())
            {
              return Ok(User_Data);
            }

            else
            {
                return BadRequest();
            }

            
        }



       




        



        [HttpPost]
        public IActionResult createUserData(UserData newData)
        {
            context.UserData.Add(newData);
            context.SaveChanges();

            return Ok(newData);
        }



        [HttpPost("LoginTest")]

        public IActionResult LoginTest(LoginDto loginDto)
        {
            var data=context.UserData.FirstOrDefault(e=>e.User_Email== loginDto.Email);
            if(data!=null)
            {
                if(data.User_Password== loginDto.Password)
                {
                    return Ok();
                }

                else
                {
                    return BadRequest();
                }

            }
           

           

            else
            {
                return BadRequest();
            }
            
        }





        [HttpGet("GetTotalFollowers")]

        public IActionResult GetTotalFollowers()
        {
            TotalFollowers totalFollowers = context.TotalFollowers.FirstOrDefault();
            if (totalFollowers != null)
            {
                return Ok(totalFollowers);
            }

            else { return BadRequest(); }

        }




    }
}
