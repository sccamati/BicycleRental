using AutoMapper;
using BicycleRental.Shared.Dto.UseCaseResponse.Bike;
using BicycleRental.Shared.Dto.UseCaseResponse.Rental;
using BicycleRental.Shared.Dto.UseCaseResponse.User;

namespace BicycleRental.Server
{
    public class AutoMaperProfile : Profile
    {
        public AutoMaperProfile()
        {
            CreateMap<User, GetUsersResponse>().ReverseMap();
            CreateMap<User, GetUserResponse>().ReverseMap();
            CreateMap<Bike, GetBikesReponse>();
            CreateMap<Rental, GetUsersRentalsResponse>();
        }
    }
}
