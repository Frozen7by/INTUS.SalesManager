using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Models.Common;
using INTUS.SalesManager.Domain.Services.Extenstions;
using INTUS.SalesManager.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace INTUS.SalesManager.Domain.Services.Lookups;
public class LookupService<TEntity> : ILookupService<TEntity>
    where TEntity : BaseLookup
{
    private readonly IRepository<TEntity> _repository;

    public LookupService(IRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public Task<List<LookupDto>> GetAll(CancellationToken cancellationToken)
    {
        return _repository.GetQueryable()
            .Select(it => it.ToLookupDto())
            .ToListAsync(cancellationToken);
    }
}
