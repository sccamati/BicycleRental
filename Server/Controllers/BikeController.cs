using AutoMapper;
using BicycleRental.Server.Services.Interfaces;
using BicycleRental.Shared.Dto.UseCaseResponse.Bike.Bike.Bike;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public async Task<ActionResult<List<GetBikeReponse>>> Get()
        {
            var bikes = await _bikeService.GetAllBikes();
            return Ok(bikes);
        }

        [HttpGet]
        public async Task<ActionResult<GetBikeReponse>> Get(int id)
        {
            var bike = await _bikeService.GetById(id);

            if (bike == null)
            {
                return BadRequest();
            }

            return _mapper.Map<GetBikeReponse>(bike);
        }

        [HttpPost]
        public async Task<ActionResult<GetBikeReponse>> Post(Bike bike)
        {
            var newBike = await _bikeService.Add(bike);
            return _mapper.Map<GetBikeReponse>(newBike);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Bike bike)
        {
            await _bikeService.Update(bike);
            return Ok();
        }
    }
}
