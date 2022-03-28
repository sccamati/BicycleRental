using BicycleRental.Server.Services.Interfaces;
using BicycleRental.Shared.Requests.User;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRental.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserRequest user)
        {
            User newUser = new User
            {
                Email = user.Email,
                Password = user.Password,
                Role = user.Role
            };

            await _userService.Add(newUser);

            return Ok();
        }

        [HttpPut]
        public async void UpdateUser([FromBody] UpdateUserRequest user)
        {
            User userToUpdate = new User
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role
            };
            await _userService.Update(userToUpdate);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById([FromQuery] int id)
        {
            User user = await _userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _userService.GetAllWithRoles();

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userService.DeleteById(id);
            return Ok();
        }
    }
}
