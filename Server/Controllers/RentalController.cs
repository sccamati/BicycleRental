using BicycleRental.Server.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BicycleRental.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {

        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Rental>>> Get()
        {
            var rentals = await _rentalService.GetAll();
            
            if(rentals == null)
            {
                return NotFound();
            }
            return Ok(rentals);
        }

        [HttpGet("id")]
        public ActionResult<List<Rental>> GetUsersRentals()
        {
            // find logged user
            int id = 0;
            var rentals = _rentalService.GetAllUsersRentals(id);

            if (rentals == null)
            {
                return NotFound();
            }
            return Ok(rentals);
        }

        [HttpPost]
        public async Task<ActionResult<Rental>> Post(Rental rental)
        {
            if (rental == null)
            {
                return BadRequest();
            }

            //add logged user and create request dto

            var newRental = _rentalService.Add(rental);
            
            if(newRental == null)
            {
                return BadRequest();
            }

            return Ok(newRental);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _rentalService.DeleteById(id);
            return Ok();
        }
    }
}
