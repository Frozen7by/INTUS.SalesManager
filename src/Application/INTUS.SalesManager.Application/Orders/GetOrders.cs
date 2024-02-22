using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Services.Orders;
using MediatR;

namespace INTUS.SalesManager.Application.Orders;

public static class GetOrders
{
    public class Request : IRequest<List<OrderDto>>
    {
    }

    public class Handler : IRequestHandler<Request, List<OrderDto>>
    {
        private readonly IOrderService _orderService;

        public Handler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public Task<List<OrderDto>> Handle(Request request, CancellationToken cancellationToken)
        {
            return _orderService.GetOrders(cancellationToken);
        }
    }
}
