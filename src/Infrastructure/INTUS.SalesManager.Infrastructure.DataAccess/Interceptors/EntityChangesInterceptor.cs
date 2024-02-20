using INTUS.SalesManager.Domain.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace INTUS.SalesManager.Infrastructure.DataAccess.Interceptors;

public class EntityChangesInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData, InterceptionResult<int> result)
    {
        OnSaveChanges(eventData);
        return result;
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        OnSaveChanges(eventData);
        return ValueTask.FromResult(result);
    }

    private void OnSaveChanges(DbContextEventData eventData)
    {
        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    OnEntityAdded(entry);
                    break;
                case EntityState.Modified:
                    OnEntityUpdated(entry);
                    break;
                case EntityState.Deleted:
                    OnEntityDeleted(entry);
                    break;
            }
        }
    }

    private void OnEntityAdded(EntityEntry entry)
    {
        if (entry.Entity is ITrackable entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
        }
    }

    private void OnEntityUpdated(EntityEntry entry)
    {
        if (entry.Entity is ITrackable entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
        }
    }

    private void OnEntityDeleted(EntityEntry entry)
    {
        if (entry.Entity is ISoftDeletable entity)
        {
            entry.State = EntityState.Modified;
            entity.DeletedDate = DateTime.UtcNow;
        }
    }
}
