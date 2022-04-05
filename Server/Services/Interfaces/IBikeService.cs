using BicycleRental.Shared.Dto.UseCaseResponse.Bike.Bike.Bike;

namespace BicycleRental.Server.Services.Interfaces
{
    public interface IBikeService : IService<Bike>
    {
        Task<List<GetBikeReponse>> GetAllBikes();
    }
}
