using AutoMapper;
using BicycleRental.Server.Repositories.Interfaces;
using BicycleRental.Server.Services.Interfaces;
using BicycleRental.Shared.Dto;
using BicycleRental.Shared.Entities;

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

        public new async Task<Bike> GetById(int id)
        {
            return await _bikeRepository.GetById(id);
        }
    }
}
