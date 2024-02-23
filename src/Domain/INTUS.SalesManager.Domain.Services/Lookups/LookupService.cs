using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Models.Common;
using INTUS.SalesManager.Domain.Services.Extenstions;
using INTUS.SalesManager.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace INTUS.SalesManager.Domain.Services.Lookups;

public class LookupService<TEntity> : ILookupService<TEntity>
    where TEntity : BaseLookup, new()
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

    public Task Add(LookupDto lookupDto, CancellationToken cancellationToken)
    {
        TEntity lookup = new()
        {
            Id = lookupDto.Id,
            Text = lookupDto.Text,
        };

        _repository.Add(lookup);
        return _repository.SaveChanges(cancellationToken);
    }

    public async Task Update(LookupDto lookupDto, CancellationToken cancellationToken)
    {
        var lookup = await _repository.GetQueryable()
            .SingleAsync(it => it.Id == lookupDto.Id, cancellationToken);
        
        lookup.Text = lookupDto.Text;
        
        await _repository.SaveChanges(cancellationToken);
    }

    public async Task Remove(LookupDto lookupDto, CancellationToken cancellationToken)
    {
        var lookup = await _repository.GetQueryable()
            .SingleAsync(it => it.Id == lookupDto.Id, cancellationToken);

        _repository.Remove(lookup);

        await _repository.SaveChanges(cancellationToken);
    }
}
