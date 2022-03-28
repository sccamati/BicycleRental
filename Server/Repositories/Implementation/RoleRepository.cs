namespace BicycleRental.Server.Repositories.Implementation
{
    public class RoleRepository : Repository<Role>
    {
        public RoleRepository(DataContext context) : base(context)
        {
        }
    }
}
