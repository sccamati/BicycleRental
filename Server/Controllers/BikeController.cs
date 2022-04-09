using AutoMapper;
using BicycleRental.Server.Services.Interfaces;
using BicycleRental.Shared.Dto.UseCaseRequest.Bike;
using BicycleRental.Shared.Dto.UseCaseResponse.Bike;
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
        public async Task<ActionResult<List<GetBikesReponse>>> Get()
        {
            var bikes = await _bikeService.GetAllBikes();
            return Ok(bikes);
        }

        [HttpGet]
        public async Task<ActionResult<GetBikesReponse>> Get(int id)
        {
            var bike = await _bikeService.GetById(id);

            if (bike == null)
            {
                return BadRequest();
            }

            return _mapper.Map<GetBikesReponse>(bike);
        }

        [HttpPost]
        public async Task<ActionResult<GetBikesReponse>> Post(CreateBikeRequest bike)
        {
            Bike newBike = _mapper.Map<Bike>(bike);

            newBike = await _bikeService.Add(newBike);
            return _mapper.Map<GetBikesReponse>(newBike);
        }

        [HttpPut]
        public async Task<ActionResult> Put(UpdateBikeRequest bike)
        {
            Bike updateBike = _mapper.Map<Bike>(bike);
            await _bikeService.Update(updateBike);
            return Ok();
        }
    }
}