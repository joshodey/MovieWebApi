using Microsoft.EntityFrameworkCore;
using MoviesWebApi.Context;
using MoviesWebApi.Entities;
using MoviesWebApi.IRepository;

namespace MoviesWebApi.Repisotory
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MovieDbContext _dbContext;

        public Repository(MovieDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<T> AddAsync(T entity, CancellationToken token)
        {
            await _dbContext.AddAsync<T>(entity, token);
            if (await SaveChangesAsync())
            {
                return entity;
            }
            return null;
        }

        private async Task<bool> SaveChangesAsync()
        {
            var isSaved = await _dbContext.SaveChangesAsync();

            return isSaved > 0;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _dbContext.Remove<T>(entity);
            return await SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(object Id)
        {
            return await _dbContext.FindAsync<T>(Id);
        }

        public async Task<bool> UpdateAsync(T entity, CancellationToken tokan)
        {
            _dbContext.Update<T>(entity);
            return await SaveChangesAsync();
        }
    }
}
