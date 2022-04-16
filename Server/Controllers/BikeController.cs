using AutoMapper;
using BicycleRental.Server.Services.Interfaces;
using BicycleRental.Shared.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRental.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeController : ControllerBase
    {
        private readonly IBikeService _bikeService;
        private readonly IMapper _mapper;
        public BikeController(IBikeService bikeService, IMapper mapper)
        {
            _bikeService = bikeService;
            _mapper = mapper;
        }

        [HttpGet("allBikes")]
        public async Task<ActionResult<List<BikeDto>>> Get()
        {
            var bikes = await _bikeService.GetAllBikes();
            return Ok(bikes);
        }

        [HttpGet]
        public async Task<ActionResult<BikeDto>> Get(int id)
        {
            var bike = await _bikeService.GetById(id);

            if (bike == null)
            {
                return BadRequest();
            }

            return _mapper.Map<BikeDto>(bike);
        }

        [HttpPost]
        public async Task<ActionResult<BikeDto>> Post(BikeDto bike)
        {
            Bike newBike = _mapper.Map<Bike>(bike);

            newBike = await _bikeService.Add(newBike);
            return _mapper.Map<BikeDto>(newBike);
        }

        [HttpPut]
        public async Task<ActionResult> Put(BikeDto bike)
        {
            Bike updateBike = _mapper.Map<Bike>(bike);
            await _bikeService.Update(updateBike);
            return Ok();
        }
    }
}