using BicycleRental.Server.Repositories.Interfaces;

namespace BicycleRental.Server.Repositories.Implementation
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(DataContext context) : base(context)
        {

        }

        public async Task<Role> GetByName(string name)
        {
            return await _context.Roles.SingleAsync(r => r.Name == name);
        }
    }
}
