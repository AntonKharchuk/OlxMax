using Microsoft.AspNetCore.Mvc;

using OlxMax.Business.FeatureServices.Interfaces;
using OlxMax.Dal.Features.UserFeatures;

namespace OlxMax.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsersController:ControllerBase
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
