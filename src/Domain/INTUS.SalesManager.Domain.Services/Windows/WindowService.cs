using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Models.Windows;
using INTUS.SalesManager.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace INTUS.SalesManager.Domain.Services.Windows;

public class WindowService : IWindowService
{
    private readonly IRepository<Window> _windowRepository;

    public WindowService(IRepository<Window> windowRepository)
    {
        _windowRepository = windowRepository;
    }

    public Task<List<WindowListDto>> GetWindows(CancellationToken cancellationToken)
    {
        return _windowRepository.GetQueryable()
            .Select(it => new WindowListDto
            {
                Id = it.Id,
                Name = it.Name,
                OrderName = it.Order.Name,
                Quantity = it.Quantity,
                TotalSubElements = it.SubElements.Count,
            }).ToListAsync(cancellationToken);
    }

    public async Task<long> AddWindow(WindowDto windowDto, CancellationToken cancellationToken)
    {
        var window = new Window
        {
            Name = windowDto.Name,
            Quantity = windowDto.Quantity,
            OrderId = windowDto.OrderId,
        };

        _windowRepository.Add(window);
        await _windowRepository.SaveChanges(cancellationToken);

        return window.Id;
    }

    public async Task UpdateWindow(WindowDto windowDto, CancellationToken cancellationToken)
    {
        var window = await _windowRepository.GetQueryable()
            .SingleAsync(it => it.Id == windowDto.Id, cancellationToken);

        window.Name = windowDto.Name;
        window.Quantity = windowDto.Quantity;

        await _windowRepository.SaveChanges(cancellationToken);
    }

    public async Task RemoveWindow(WindowDto windowDto, CancellationToken cancellationToken)
    {
        var window = await _windowRepository.GetQueryable()
            .SingleAsync(it => it.Id == windowDto.Id, cancellationToken);

        _windowRepository.Remove(window);

        await _windowRepository.SaveChanges(cancellationToken);
    }

    public Task<WindowDto> GetWindow(long id, CancellationToken cancellationToken)
    {
        return _windowRepository.GetQueryable()
            .Where(it => it.Id == id)
            .Select(it => new WindowDto
            {
                Id = it.Id,
                Name = it.Name,
                Quantity = it.Quantity,
                OrderId = it.OrderId,
            })
            .SingleAsync(cancellationToken);
    }
}
