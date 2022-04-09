using BicycleRental.Shared.Dto.UseCaseResponse.Bike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental.Shared.Dto.UseCaseResponse.Rental
{
    public class GetUsersRentalsResponse
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public GetBikesReponse Bike { get; set; }
    }
}
