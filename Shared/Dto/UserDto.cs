using BicycleRental.Shared.Entities;

namespace BicycleRental.Shared.Dto
{
    public class UserDto : BaseEntity
    {
        public string Email { get; set; }
        public RoleDto Role { get; set; }
        public List<RentalDto> Rentals { get; set; }
    }
}
