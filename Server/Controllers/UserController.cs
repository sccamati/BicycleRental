using BicycleRental.Server.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRental.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly DataContext _dataContext;
        public UserController(IUserService userService, DataContext dataContext)
        {
            _userService = userService;
            _dataContext = dataContext;   
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            User user = await _userService.GetById(id);
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _userService.GetAllWithRoles();
            return Ok(users);
        }
    }
}
