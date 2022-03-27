using BicycleRental.Shared.Responses;

namespace BicycleRental.Client.Services.UserService
{
    public interface IUserService
    {
        public List<GetUserResponse> Users { get; set; }

        Task GetUsers();
        Task<GetUserResponse> GetUserById(int id);
    }
}
