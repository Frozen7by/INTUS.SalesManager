using INTUS.SalesManager.Common.Models;

namespace INTUS.SalesManager.Domain.Services.Orders;

public interface IOrderService
{
    Task<List<OrderDto>> GetOrders(CancellationToken cancellationToken);
}