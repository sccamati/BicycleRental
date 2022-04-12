using BicycleRental.Shared.Dto;

namespace BicycleRental.Server.Services.Interfaces
{
    public interface IAuthService
    {
        Task<User> Register(AuthDto userDto);
        Task<string> Login(AuthDto userDto);
    }
}
