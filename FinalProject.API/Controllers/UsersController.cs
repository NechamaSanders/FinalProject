using Microsoft.AspNetCore.Mvc;
using FinalProject.BL.DTOs;
using FinalProject.BL.Services;

namespace FinalProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var chefs = await _userService.GetAllUsersAsync();
            return Ok(chefs);
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserCreateDto userCreateDto)
        {
            await _userService.CreateUserAsync(userCreateDto);
            return StatusCode(201); 
        }
    }
}