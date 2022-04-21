using BicycleRental.Shared.Dto;
using BicycleRental.Shared.Entities;

namespace BicycleRental.Server.Services.Interfaces
{
    public interface IBikeService : IService<Bike>
    {
        Task<List<BikeDto>> GetAllBikes();
        new Task<Bike> GetById(int id);
    }
}
