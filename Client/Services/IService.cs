namespace BicycleRental.Client.Services
{
    public interface IService<T> where T : class
    {
        Task<List<T>> GetAllAsync<T>(string requestUri);
        Task<T> GetByIdAync(string requestUri, int id);
        Task<T> DeleteByIdAsync(string requestUri, int id);
        Task<T> UpdateAsync(string requestUri, T entity);
        Task<T> CreateAsync(string requestUri, T entity);
    }
}
