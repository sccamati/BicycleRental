using BicycleRental.Server.Services.Interfaces;
using BicycleRental.Shared.Dto.UseCaseRequest.User;
using BicycleRental.Shared.Dto.UseCaseResponse.Bike.Bike.User;
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
        public async Task<IActionResult> Post([FromBody] UserRequest user)
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
        public async void Put([FromBody] UpdateUserRequest user)
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
        public async Task<ActionResult<GetUserResponse>> Get([FromQuery] int id)
        {
            var user = await _userService.GetByIdWithRentals(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            var users = await _userService.GetAllWithRoles();

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.DeleteById(id);
            return Ok();
        }
    }
}
