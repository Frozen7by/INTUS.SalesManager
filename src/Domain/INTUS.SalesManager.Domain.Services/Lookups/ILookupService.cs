using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Models.Common;

namespace INTUS.SalesManager.Domain.Services.Lookups;

public interface ILookupService<TEntity>
    where TEntity : BaseLookup
{
    Task Add(LookupDto lookupDto, CancellationToken cancellationToken);

    Task<LookupDto?> Get(long id, CancellationToken cancellationToken);

    Task<List<LookupDto>> GetAll(CancellationToken cancellationToken);

    Task Remove(LookupDto lookupDto, CancellationToken cancellationToken);

    Task Update(LookupDto lookupDto, CancellationToken cancellationToken);
}