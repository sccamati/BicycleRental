using BicycleRental.Shared.Dto.UseCaseResponse.Rental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental.Shared.Dto.UseCaseResponse.User
{
    public class GetUserResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public List<GetUsersRentalsResponse> Rentals { get; set; }
    }
}
