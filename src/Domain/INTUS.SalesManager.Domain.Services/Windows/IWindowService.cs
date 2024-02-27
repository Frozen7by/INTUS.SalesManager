using INTUS.SalesManager.Common.Models;

namespace INTUS.SalesManager.Domain.Services.Windows;

public interface IWindowService
{
    Task<long> AddWindow(WindowDto windowDto, CancellationToken cancellationToken);

    Task<WindowDto> GetWindow(long id, CancellationToken cancellationToken);

    Task<List<WindowListDto>> GetWindows(CancellationToken cancellationToken);

    Task RemoveWindow(WindowDto windowDto, CancellationToken cancellationToken);

    Task UpdateWindow(WindowDto windowDto, CancellationToken cancellationToken);
}