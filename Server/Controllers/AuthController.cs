using BicycleRental.Server.Services.Interfaces;
using BicycleRental.Shared.Dto.UseCaseRequest.User;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRental.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            User user = await _authService.Register(request);
            return Ok(user);

        }

        [HttpPost]
        public async Task<ActionResult<User>> Login(UserDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("User Not Found");
            }



        }

    }
}
