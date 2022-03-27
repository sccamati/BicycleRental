using AutoMapper;
using BicycleRental.Shared.Responses;

namespace BicycleRental.Server
{
    public class AutoMaperProfile : Profile
    {
        public AutoMaperProfile()
        {
            CreateMap<User, GetUserResponse>().ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name)).ReverseMap();
        }
    }
}
