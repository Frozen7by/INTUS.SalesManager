using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Models.Common;

namespace INTUS.SalesManager.Domain.Services.Lookups;
public interface ILookupService<TEntity>
    where TEntity : BaseLookup
{
    Task<List<LookupDto>> GetAll(CancellationToken cancellationToken);
}