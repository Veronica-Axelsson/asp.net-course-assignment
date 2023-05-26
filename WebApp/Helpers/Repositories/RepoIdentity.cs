using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApp.Context;

namespace WebApp.Helpers.Repositories;

public class RepoIdentity<TEntity> where TEntity : class
{
    #region constructors & private fields

    private readonly IdentityContext _identityContext;

    public RepoIdentity(IdentityContext identityContext)
    {
        _identityContext = identityContext;
    }

    #endregion

    public virtual async Task<TEntity> AddAsync(TEntity entity)
    {
        _identityContext.Set<TEntity>().Add(entity);
        await _identityContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = await _identityContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
        return entity!;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var entity = await _identityContext.Set<TEntity>().ToListAsync();
        return entity!;
    }



}
