using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Services.Orders;
using MediatR;

namespace INTUS.SalesManager.Application.Orders;

public static class UpdateOrder
{
    public class Request : OrderDto, IRequest<Unit>
    {
    }

    public class Handler : IRequestHandler<Request, Unit>
    {
        private readonly IOrderService _service;

        public Handler(IOrderService service)
        {
            _service = service;
        }

        public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
        {
            await _service.UpdateOrder(request, cancellationToken);
            return Unit.Value;
        }
    }
}
