namespace BicycleRental.Server.Abstraction
{
    public interface IService<T>
    {
        Task Add(T item);
        Task Update(T item);
        Task Delete(T item);
        Task DeleteById(int id);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
    }
}
