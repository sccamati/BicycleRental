using BicycleRental.Server.Repositories.Interfaces;
using BicycleRental.Server.Services.Interfaces;

namespace BicycleRental.Server.Services.Implementation
{
    public class RentalService : Service<Rental>, IRentalService
    {
        private readonly IRentalRepository _rentalRepo;
        public RentalService(IRepository<Rental> repository, IRentalRepository rentalRepo) : base(repository)
        {
            _rentalRepo = rentalRepo;
        }

        public List<Rental> GetAllUsersRentals(int id)
        {
            var rentals = _rentalRepo.GetAllUsersRentals(id);
            return rentals;
        }
    }
}
