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

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserCreateDto userCreateDto)
        {
            await _userService.CreateUserAsync(userCreateDto);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UserCreateDto userDto)
        {
            var success = await _userService.UpdateUserAsync(id, userDto);
            if (!success) return NotFound(new { message = "User not found" });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _userService.DeleteUserAsync(id);
            if (!success) return NotFound(new { message = "User not found" });

            return NoContent();
        }
    }
}