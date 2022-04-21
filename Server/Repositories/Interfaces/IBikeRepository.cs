using BicycleRental.Shared.Entities;

namespace BicycleRental.Server.Repositories.Interfaces
{
    public interface IBikeRepository : IRepository<Bike>
    {
        new Task<List<Bike>> GetAll();
        new Task<Bike> GetById(int id);
    }
}

