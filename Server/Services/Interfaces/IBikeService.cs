using BicycleRental.Shared.Dto;

namespace BicycleRental.Server.Services.Interfaces
{
    public interface IBikeService : IService<Bike>
    {
        Task<List<BikeDto>> GetAllBikes();
    }
}
