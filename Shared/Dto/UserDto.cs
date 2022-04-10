using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BicycleRental.Shared.Dto
{
    public class UserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public List<Rental> Rentals { get; set; }
        public string Token { get; set; }
    }
}
