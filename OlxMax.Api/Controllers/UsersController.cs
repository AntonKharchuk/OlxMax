using Microsoft.AspNetCore.Mvc;

using OlxMax.Business.FeatureServices.Interfaces;
using OlxMax.Dal.Features.UserFeatures;

namespace OlxMax.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();

            return Ok(users);
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var canLogin = await _userService.CanLogInUserAsync(model.Username, model.Password);

            if (canLogin)
            {
                return Ok(new { message = "Login successful" });
            }
            else
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }
        }
        public record LoginRequest
        {
            public string? Username { get; set; }
            public string? Password { get; set; }
        }

        [HttpGet("username/{userName}")]
        public async Task<IActionResult> CanLogIn(string userName)
        {
            var user = await _userService.GetUserByUserNameAsync(userName);

            return Ok(user);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetUserByIdAsync(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            return Ok(user);
        }

        [HttpPost]

        public async Task<IActionResult> CreateNewUserAsync([FromBody] CreateUserDto createUserDto)
        {
            var user = await _userService.AddNewUserAsync(createUserDto);

            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUserDto updateUserDto)
        {
            var user = await _userService.UpdateUserAsync(updateUserDto);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            var user = await _userService.DeleteUserAsync(id);
            return Ok(user);
        }
    }
}
