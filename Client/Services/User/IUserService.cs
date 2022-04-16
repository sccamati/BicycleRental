using BicycleRental.Shared.Dto;

namespace BicycleRental.Client.Services.UserService
{
    public interface IUserService : IService<UserDto>
    {
        public List<UserDto> Users { get; set; }
        public UserDto User { get; set; }
    }
}
