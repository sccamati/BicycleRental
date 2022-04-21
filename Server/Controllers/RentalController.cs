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
    [Authorize(Roles = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {

        private readonly IRentalService _rentalService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public RentalController(IRentalService rentalService, IUserService userService, IMapper mapper)
        {
            _rentalService = rentalService;
            _userService = userService;
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
        public ActionResult<List<RentalDto>> GetUsersRentals()
        {
            int id = Jwt.GetId(Request.Headers.Authorization);
            var rentals = _rentalService.GetAllUsersRentals(id);

            if (rentals == null)
            {
                return NotFound();
            }
            var rentalsDto = _mapper.Map<List<Rental>, List<RentalDto>>(rentals);
            return Ok(rentalsDto);
        }

        [HttpPost]
        public async Task<ActionResult<RentalDto>> Post(RentalDto rental)
        {
            if (rental == null)
            {
                return BadRequest();
            }

            string token = Request.Headers.Authorization;

            Rental addRental = _mapper.Map<Rental>(rental);

            User user = await _userService.GetById(Jwt.GetId(token));

            addRental.User = user;

            var newRental = _rentalService.Add(addRental);

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
    }
}
