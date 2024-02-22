using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Services.Orders;
using MediatR;

namespace INTUS.SalesManager.Application.Orders;

public static class GetOrder
{
    public class Request : IRequest<OrderDto>
    {
        public long Id { get; set; }
    }

    public class Handler : IRequestHandler<Request, OrderDto>
    {
        private readonly IOrderService _orderService;

        public Handler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public Task<OrderDto> Handle(Request request, CancellationToken cancellationToken)
        {
            return _orderService.GetOrder(request.Id, cancellationToken);
        }
    }
}
