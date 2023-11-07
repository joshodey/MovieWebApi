using MoviesWebApi.Entities;

namespace MoviesWebApi.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity, CancellationToken token);
        Task<bool> UpdateAsync(T entity, CancellationToken tokan);
        Task<bool> DeleteAsync(T entity);
        Task<T> GetAsync(object Id);
        Task<List<T>> GetAllAsync();
    }
}
