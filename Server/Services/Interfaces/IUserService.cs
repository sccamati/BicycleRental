using BicycleRental.Shared.Responses;

namespace BicycleRental.Server.Services.Interfaces
{
    public interface IUserService : IService<User>
    {
        Task<List<GetUserResponse>> GetAllWithRoles();
    }
}
