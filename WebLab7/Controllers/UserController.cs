using Microsoft.AspNetCore.Mvc;
using WebLab7.Filters;
using WebLab7.Models;
using WebLab7.Services.Intefaces;

namespace WebLab7.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    [HATEOASFilter]
    public class UserController(IUserService userService) : Controller
    {
        [HttpPost]
        public async Task<UserDto> CreateUser([FromBody] UserDto dto)
        {
            return await userService.CreateUser(dto);
        }

        [HttpGet]
        public async Task<UserDto> GetUser([FromQuery] long id)
        {
            return await userService.GetUser(id);
        }

        [HttpPut]
        public async Task<UserDto> UpdateUser([FromBody] UserDto dto)
        {
            return await userService.UpdateUser(dto);
        }

        [HttpDelete]
        public async Task<UserDto> DeleteUser([FromQuery] long id)
        {
            return await userService.DeleteUser(id);
        }
    }
}
