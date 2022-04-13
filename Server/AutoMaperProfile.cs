using AutoMapper;
using BicycleRental.Shared.Dto;

namespace BicycleRental.Server
{
    public class AutoMaperProfile : Profile
    {
        public AutoMaperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Bike, BikeDto>();
            CreateMap<Rental, RentalDto>().ReverseMap();
            CreateMap<BikesType, BikesTypeDto>().ReverseMap();
        }
    }
}
