namespace INTUS.SalesManager.Infrastructure.Common;

public interface IRepository<TEntity> where TEntity : class
{
    public IQueryable<TEntity> GetQueryable(bool asTracking = false);

    public Task SaveChanges(CancellationToken cancellationToken = default);
}
