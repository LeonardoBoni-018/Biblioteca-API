using BibliotecaAPI.Dto;
using BibliotecaAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id) {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateUserDto createUserDto)
        {
            var user = await _userService.CreateAsync(createUserDto);
            return Ok(user);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(int id, CreateUserDto createUserDto)
        {
            var user = await _userService.UpdateAsync(id, createUserDto);
            if (user == null)
            {
                return BadRequest("User not found");
            }
            return Ok(user);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _userService.DeleteAsync(id);
            if (!deleted)
            {
                return BadRequest("User not found");
            }
            return Ok();
        }

    }
}
