using BicycleRental.Shared.Dto;

namespace BicycleRental.Server.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthDto> Register(AuthRegisterDto userDto);
        Task<string> Login(AuthDto userDto);
    }
}
