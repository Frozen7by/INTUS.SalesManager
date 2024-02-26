using INTUS.SalesManager.Common.Models;

namespace INTUS.SalesManager.Domain.Services.SubElements;

public interface ISubElementService
{
    Task<long> AddSubElement(SubElementDto subElementDto, CancellationToken cancellationToken);

    Task<SubElementDto> GetSubElement(long id, CancellationToken cancellationToken);

    Task<List<SubElementDto>> GetSubElements(long windowId, CancellationToken cancellationToken);

    Task<bool> IsElementTypeUsed(long elementTypeId, CancellationToken cancellationToken);

    Task RemoveSubElement(SubElementDto subElementDto, CancellationToken cancellationToken);

    Task UpdateSubElement(SubElementDto subElementDto, CancellationToken cancellationToken);
}