using AutoMapper;
using BicycleRental.Server.Services.Interfaces;
using BicycleRental.Shared.Dto;
using BicycleRental.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRental.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IUserService userService, IMapper mapper)
        {
            _authService = authService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(AuthRegisterDto request)
        {
            AuthDto user = await _authService.Register(request);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok();

        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<User>> Login(AuthDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("User Not Found");
            }

            var token = await _authService.Login(request);

            if (token == null)
            {
                return BadRequest();
            }

            return Ok(token);

        }

    }
}
