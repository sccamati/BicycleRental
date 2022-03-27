
namespace BicycleRental.Server.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task Add(T item);
        Task Update(T item);
        Task DeleteById(int id);
        Task Delete(T item);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
    }
}
