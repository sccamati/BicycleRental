namespace BicycleRental.Server.Repositories.Interfaces
{
    public interface IBikeRepository : IRepository<Bike>
    {
        new Task<List<Bike>> GetAll();
    }
}

