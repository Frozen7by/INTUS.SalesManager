using INTUS.SalesManager.Common.Models;

namespace INTUS.SalesManager.Domain.Services.Orders;

public interface IOrderService
{
    Task<OrderDto> GetOrder(long id, CancellationToken cancellationToken);

    Task<List<OrderListDto>> GetOrders(CancellationToken cancellationToken);
}