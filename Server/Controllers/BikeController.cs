using AutoMapper;
using BicycleRental.Server.Services.Interfaces;
using BicycleRental.Shared.Dto;
using BicycleRental.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRental.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BikeController : ControllerBase
    {
        private readonly IBikeService _bikeService;
        private readonly IBikesTypeService _bikesTypeService;
        private readonly IMapper _mapper;
        public BikeController(IBikeService bikeService, IMapper mapper, IBikesTypeService bikesTypeService)
        {
            _bikeService = bikeService;
            _mapper = mapper;
            _bikesTypeService = bikesTypeService;
        }

        [HttpGet("allBikes")]
        public async Task<ActionResult<List<BikeDto>>> Get()
        {
            var bikes = await _bikeService.GetAllBikes();
            return Ok(bikes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BikeDto>> Get(int id)
        {
            var bike = await _bikeService.GetById(id);

            if (bike == null)
            {
                return BadRequest();
            }

            var response = _mapper.Map<BikeDto>(bike);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<BikeDto>> Post(BikeDto request)
        {
            BikesType bikesType = await _bikesTypeService.GetById(request.BikesType.Id);
            Bike bike = _mapper.Map<Bike>(request);
            bike.BikesType = bikesType;

            var newBike = await _bikeService.Add(bike);
            var response = _mapper.Map<BikeDto>(newBike);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult> Put(BikeDto bike)
        {
            Bike updateBike = _mapper.Map<Bike>(bike);
            await _bikeService.Update(updateBike);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _bikeService.DeleteById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}