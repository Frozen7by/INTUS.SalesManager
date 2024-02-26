using INTUS.SalesManager.Application.Orders;
using INTUS.SalesManager.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace INTUS.SalesManager.Api.Web.Controllers;

[ApiController]
[Route("/api/v1/orders")]
public class OrdersController : Controller
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public Task<List<OrderListDto>> GetOrders()
    {
        return _mediator.Send(new GetOrders.Request());
    }

    [HttpGet("{id}")]
    public Task<OrderDto> GetOrder([FromRoute] GetOrder.Request request)
    {
        return _mediator.Send(request);
    }

    [HttpPost]
    public Task AddOrder([FromBody] AddOrder.Request request)
    {
        return _mediator.Send(request);
    }

    [HttpPut]
    public Task UpdateOrder([FromBody] UpdateOrder.Request request)
    {
        return _mediator.Send(request);
    }

    [HttpDelete("{id}")]
    public Task RemoveOrder([FromRoute] RemoveOrder.Request request)
    {
        return _mediator.Send(request);
    }
}
