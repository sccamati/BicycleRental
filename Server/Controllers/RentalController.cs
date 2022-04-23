using AutoMapper;
using BicycleRental.Server.Helpers;
using BicycleRental.Server.Services.Interfaces;
using BicycleRental.Shared.Dto;
using BicycleRental.Shared.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BicycleRental.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {

        private readonly IRentalService _rentalService;
        private readonly IUserService _userService;
        private readonly IBikeService _bikeService;
        private readonly IMapper _mapper;

        public RentalController(IRentalService rentalService, IUserService userService, IBikeService bikeService, IMapper mapper)
        {
            _rentalService = rentalService;
            _userService = userService;
            _bikeService = bikeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<RentalDto>>> Get()
        {
            var rentals = await _rentalService.GetAll();

            if (rentals == null)
            {
                return NotFound();
            }
            var rentalsDto = _mapper.Map<List<Rental>, List<RentalDto>>(rentals);
            return Ok(rentalsDto);
        }

        [HttpGet("userRentals")]
        public async Task<ActionResult<List<RentalDto>>> GetUsersRentals()
        {
            int id = Jwt.GetId(Request.Headers.Authorization);
            var rentals = await _rentalService.GetAllUsersRentals(id);
            foreach (var rental in rentals)
            {
                if(rental.Price == 0)
                {
                    rental.Price = (DateTime.Now.AddHours(1) - rental.StartDate).Hours * rental.Bike.PricePerHour;
                }
            }

            if (rentals == null)
            {
                return NotFound();
            }
            var rentalsDto = _mapper.Map<List<Rental>, List<RentalDto>>(rentals);
            return Ok(rentalsDto);
        }

        [HttpPost]
        public async Task<ActionResult<RentalDto>> Post(RentalBikeDto request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            string token = Request.Headers.Authorization;

            User user = await _userService.GetById(Jwt.GetId(token));

            Rental rental = new Rental
            {
                Bike = await _bikeService.GetById(request.Id),
                StartDate = DateTime.Now,
                User = user,
            };

            rental.Bike.IsBorrowed = true;

            var newRental = await _rentalService.Add(rental);

            if (newRental == null)
            {
                return BadRequest();
            }

            var rentalsDto = _mapper.Map<RentalDto>(newRental);
            return Ok(rentalsDto);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _rentalService.DeleteById(id);
            return Ok();
        }

        [HttpPut("returnBike")]
        public async Task<ActionResult> ReturnBike(RentalDto request)
        {
            try
            {
                await _rentalService.ReturnBike(request.Id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
