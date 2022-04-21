using AutoMapper;
using BicycleRental.Server.Services.Interfaces;
using BicycleRental.Shared.Dto;
using BicycleRental.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRental.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikesTypeController : ControllerBase
    {
        private readonly IBikesTypeService _bikesTypeService;
        private readonly IMapper _mapper;
        public BikesTypeController(IBikesTypeService bikesTypeService, IMapper mapper)
        {
            _bikesTypeService = bikesTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<BikesTypeDto>>> Get()
        {
            var bikesTypes = await _bikesTypeService.GetAll();
            var bikesDto = _mapper.Map<List<BikesType>, List<BikesTypeDto>>(bikesTypes);
            return Ok(bikesDto); 
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
        public async Task<ActionResult> Put(BikesTypeDto bikesType)
        {
            BikesType type = new BikesType
            {
                Id = bikesType.Id,
                Name = bikesType.Name,
            };
            await _bikesTypeService.Update(type);
            return Ok();
        }
    }
}
