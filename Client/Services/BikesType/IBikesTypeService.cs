using BicycleRental.Shared.Dto;

namespace BicycleRental.Client.Services.BikesType
{
    public interface IBikesTypeService : IService<BikesTypeDto>
    {
        public List<BikesTypeDto> Types { get; set; }
    }
}
