using AutoMapper;
using BicycleRental.Shared.Dto.UseCaseResponse.Bike.Bike.Bike;
using BicycleRental.Shared.Dto.UseCaseResponse.Bike.Bike.User;

namespace BicycleRental.Server
{
    public class AutoMaperProfile : Profile
    {
        public AutoMaperProfile()
        {
            CreateMap<User, GetUsersResponse>().ReverseMap();
            CreateMap<User, GetUserResponse>().ReverseMap();
            CreateMap<Bike, GetBikeReponse>();
        }
    }
}
