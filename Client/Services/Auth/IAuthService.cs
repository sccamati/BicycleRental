using BicycleRental.Shared.Dto;

namespace BicycleRental.Client.Services.Auth
{
    public interface IAuthService
    {
        Task<string> Login(AuthDto user);
        Task<AuthDto> Register(AuthDto user);
    }
}
