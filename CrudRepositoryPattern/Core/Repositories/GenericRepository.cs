using CrudRepositoryPattern.Data;
using Microsoft.EntityFrameworkCore;

namespace CrudRepositoryPattern.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApiDbContext _context;
        internal DbSet<T> _dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(
            ApiDbContext context,
            ILogger Logger)
        {
            _context = context;
            _logger = Logger;
            this._dbSet = context.Set<T>();

        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await _dbSet.AsNoTracking(). ToListAsync();
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Add(T entity)
        {
             await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Update(T entity)
        {
            _dbSet.Update(entity);
            return true;
        }

        public virtual async Task<bool> Delete(T entity)
        {
            _dbSet.Remove(entity);
            return true;
        }
    }
}
