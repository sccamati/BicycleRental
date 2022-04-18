using BicycleRental.Shared.Dto;

namespace BicycleRental.Client.Services.Bike
{
    public interface IBikeService : IService<BikeDto>
    {
        public BikeDto Bike { get; set; }
    }
}
