using BicycleRental.Server.Services.Interfaces;
using BicycleRental.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRental.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string name)
        {
            Role role = new Role
            {
                Name = name,
            };

            var newRole = await _roleService.Add(role);

            return Ok(newRole);
        }

        [HttpGet]
        public async Task<ActionResult<List<Role>>> Get()
        {
            var roles = await _roleService.GetAll();
            return Ok(roles);
        }
    }
}
