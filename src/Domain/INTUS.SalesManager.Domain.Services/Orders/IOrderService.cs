using INTUS.SalesManager.Common.Models;

namespace INTUS.SalesManager.Domain.Services.Orders;

public interface IOrderService
{
    Task<long> AddOrder(OrderDto orderDto, CancellationToken cancellationToken);

    Task<OrderDto> GetOrder(long id, CancellationToken cancellationToken);

    Task<List<OrderListDto>> GetOrders(CancellationToken cancellationToken);

    Task RemoveOrder(OrderDto orderDto, CancellationToken cancellationToken);

    Task UpdateOrder(OrderDto orderDto, CancellationToken cancellationToken);
}