using BicycleRental.Shared.Dto;

namespace BicycleRental.Server.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> Register(UserDto userDto);
        Task<string> Login(UserDto userDto);
    }
}
