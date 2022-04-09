using BicycleRental.Shared.Dto.UseCaseResponse.Bike;
using BicycleRental.Shared.Dto.UseCaseResponse.User;

namespace BicycleRental.Server.Services.Interfaces
{
    public interface IUserService : IService<User>
    {
        Task<List<GetUsersResponse>> GetAllWithRoles();
        Task<GetUserResponse> GetByIdWithRentals(int id);
    }
}
