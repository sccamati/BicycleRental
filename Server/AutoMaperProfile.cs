using AutoMapper;
using BicycleRental.Shared.Dto;
using BicycleRental.Shared.Entities;

namespace BicycleRental.Server
{
    public class AutoMaperProfile : Profile
    {
        public AutoMaperProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, AuthDto>().ReverseMap();
            CreateMap<Bike, BikeDto>().ReverseMap();
            CreateMap<Rental, RentalDto>().ReverseMap();
            CreateMap<BikesType, BikesTypeDto>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
        }
    }
}
