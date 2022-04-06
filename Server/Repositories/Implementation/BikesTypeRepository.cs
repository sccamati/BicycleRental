namespace BicycleRental.Server.Repositories.Implementation
{
    public class BikesTypeRepository : Repository<BikesType>
    {
        public BikesTypeRepository(DataContext context) : base(context)
        {
        }
    }
}
