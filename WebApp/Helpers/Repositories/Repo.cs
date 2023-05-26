using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebApp.Context;

namespace WebApp.Helpers.Repositories
{
    public class Repo<TEntity> where TEntity : class
    {
        #region constructors & private fields

        private readonly DataContext _context;

        public Repo(DataContext context)
        {
            _context = context;

        }
        #endregion


        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            return entity!;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entity = await _context.Set<TEntity>().ToListAsync();
            return entity!;
        }

    
    }
}
