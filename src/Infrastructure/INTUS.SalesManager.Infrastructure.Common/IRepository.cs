namespace INTUS.SalesManager.Infrastructure.Common;

public interface IRepository<TEntity> where TEntity : class
{
    void Add(TEntity entity);

    public IQueryable<TEntity> GetQueryable(bool asTracking = false);

    void Remove(TEntity entity);

    public Task SaveChanges(CancellationToken cancellationToken = default);

    void Update(TEntity entity);
}
