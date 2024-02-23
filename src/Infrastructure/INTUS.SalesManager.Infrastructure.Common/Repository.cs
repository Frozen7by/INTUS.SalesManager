using Microsoft.EntityFrameworkCore;

namespace INTUS.SalesManager.Infrastructure.Common;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbContext _dbContext;

    public Repository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<TEntity> GetQueryable(bool asTracking = false)
    {
        var set = _dbContext.Set<TEntity>()
            .AsQueryable();

        if (!asTracking)
        {
            set = set.AsNoTracking();
        }

        return set;
    }

    public void Add(TEntity entity)
    {
        _dbContext.Add(entity);
    }

    public void Update(TEntity entity)
    {
        _dbContext.Update(entity);
    }

    public void Remove(TEntity entity)
    {
        _dbContext.Remove(entity);
    }

    public Task SaveChanges(CancellationToken cancellationToken = default)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}
