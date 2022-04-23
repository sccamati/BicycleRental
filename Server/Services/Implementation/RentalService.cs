using BicycleRental.Server.Repositories.Interfaces;
using BicycleRental.Server.Services.Interfaces;
using BicycleRental.Shared.Entities;

namespace BicycleRental.Server.Services.Implementation
{
    public class RentalService : Service<Rental>, IRentalService
    {
        private readonly IRentalRepository _rentalRepo;
        public RentalService(IRepository<Rental> repository, IRentalRepository rentalRepo) : base(repository)
        {
            _rentalRepo = rentalRepo;
        }

        public async Task<List<Rental>> GetAllUsersRentals(int id)
        {
            var rentals = await _rentalRepo.GetAllUsersRentals(id);
            return rentals;
        }

        public async Task<Rental> GetByIdWithBike(int id)
        {
            var rental = await _rentalRepo.GetByIdWithBike(id);
            return rental;
        }

        public async Task ReturnBike(int id)
        {
            var rental = await _rentalRepo.GetByIdWithBike(id);

            rental.Bike.IsBorrowed = false;
            rental.EndDate = DateTime.Now;
            rental.Price = (rental.EndDate - rental.StartDate).Hours * rental.Bike.PricePerHour;

            await _rentalRepo.Update(rental);
        }
    }
}
