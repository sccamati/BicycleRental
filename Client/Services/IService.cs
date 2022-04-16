namespace BicycleRental.Client.Services
{
    public interface IService<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync(string requestUri);
        Task<T> GetByIdAync(string requestUri, T entity);
        Task<bool> DeleteByIdAsync(string requestUri, T entity);
        Task<T> UpdateAsync(string requestUri, T entity);
        Task<T> CreateAsync(string requestUri, T entity);
    }
}
