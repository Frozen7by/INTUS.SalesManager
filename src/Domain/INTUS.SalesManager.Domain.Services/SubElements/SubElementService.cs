using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Models.SubElements;
using INTUS.SalesManager.Domain.Services.Extenstions;
using INTUS.SalesManager.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace INTUS.SalesManager.Domain.Services.SubElements;

public class SubElementService : ISubElementService
{
    private readonly IRepository<SubElement> _subElementRepository;

    public SubElementService(IRepository<SubElement> subElementRepository)
    {
        _subElementRepository = subElementRepository;
    }

    public Task<List<SubElementDto>> GetSubElements(CancellationToken cancellationToken)
    {
        return _subElementRepository.GetQueryable()
            .Select(it => new SubElementDto
            {
                Id = it.Id,
                Index = it.Index,
                ElementType = it.ElementType.ToLookupDto(),
                Width = it.Width,
                Height = it.Height,
                WindowId = it.WindowId,
                WindowName = it.Window.Name,
            }).ToListAsync(cancellationToken);
    }

    public async Task<long> AddSubElement(SubElementDto subElementDto, CancellationToken cancellationToken)
    {
        var subElement = new SubElement
        {
            Index = subElementDto.Index,
            ElementTypeId = subElementDto.ElementType.Id,
            Width = subElementDto.Width,
            Height = subElementDto.Height,
            WindowId = subElementDto.WindowId,
        };

        _subElementRepository.Add(subElement);
        await _subElementRepository.SaveChanges(cancellationToken);

        return subElement.Id;
    }

    public async Task UpdateSubElement(SubElementDto subElementDto, CancellationToken cancellationToken)
    {
        var subElement = await _subElementRepository.GetQueryable()
            .SingleAsync(it => it.Id == subElementDto.Id, cancellationToken);

        subElement.Index = subElementDto.Index;
        subElement.ElementTypeId = subElementDto.ElementType.Id;
        subElement.Width = subElementDto.Width;
        subElement.Height = subElementDto.Height;

        await _subElementRepository.SaveChanges(cancellationToken);
    }

    public async Task RemoveSubElement(SubElementDto subElementDto, CancellationToken cancellationToken)
    {
        var subElement = await _subElementRepository.GetQueryable()
            .SingleAsync(it => it.Id == subElementDto.Id, cancellationToken);

        _subElementRepository.Remove(subElement);

        await _subElementRepository.SaveChanges(cancellationToken);
    }

    public Task<SubElementDto> GetSubElement(long id, CancellationToken cancellationToken)
    {
        return _subElementRepository.GetQueryable()
            .Where(it => it.Id == id)
            .Select(it => new SubElementDto
            {
                Id = it.Id,
                Index = it.Index,
                ElementType = it.ElementType.ToLookupDto(),
                Width = it.Width,
                Height = it.Height,
                WindowId = it.WindowId,
            })
            .SingleAsync(cancellationToken);
    }

    public Task<bool> IsElementTypeUsed(long elementTypeId, CancellationToken cancellationToken)
    {
        return _subElementRepository.GetQueryable()
            .AnyAsync(it => it.ElementTypeId == elementTypeId, cancellationToken);
    }
}
