using AutoMapper;
using BicycleRental.Server.Repositories.Interfaces;
using BicycleRental.Server.Services.Interfaces;
using BicycleRental.Shared.Dto;

namespace BicycleRental.Server.Services.Implementation
{
    public class BikeService : Service<Bike>, IBikeService
    {
        private readonly IMapper _mapper;
        private readonly IBikeRepository _bikeRepository;
        public BikeService(IRepository<Bike> repository, IMapper mapper, IBikeRepository bikeRepository) : base(repository)
        {
            _mapper = mapper;
            _bikeRepository = bikeRepository;
        }

        public async Task<List<BikeDto>> GetAllBikes()
        {
            var bikes = await _bikeRepository.GetAll();
            return _mapper.Map<List<Bike>, List<BikeDto>>(bikes);
        }
    }
}
