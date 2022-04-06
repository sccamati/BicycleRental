using BicycleRental.Server.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRental.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikesTypeController : ControllerBase
    {
        private readonly IBikesTypeService _bikesTypeService;

        public BikesTypeController(IBikesTypeService bikesTypeService)
        {
            _bikesTypeService = bikesTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BikesType>>> Get()
        {
            var bikesTypes = await _bikesTypeService.GetAll();
            return Ok(bikesTypes); 
        }

        [HttpPost]
        public async Task<ActionResult> Post(string name)
        {
            BikesType bikesType = new BikesType
            {
                Name = name
            };

            var newType = await _bikesTypeService.Add(bikesType);
            return Ok(newType);
        }

        [HttpPut]
        public async Task<ActionResult> Put(BikesType bikesType)
        {
            await _bikesTypeService.Update(bikesType);
            return Ok();
        }
    }
}
