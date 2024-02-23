using INTUS.SalesManager.Application.Lookups;
using INTUS.SalesManager.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace INTUS.SalesManager.Api.Web.Controllers;

[ApiController]
[Route("/api/v1/lookups")]
public class LookupsController : Controller
{
    private readonly IMediator _mediator;

    public LookupsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("elementTypes")]
    public Task<List<LookupDto>> GetTypes()
    {
        return _mediator.Send(new GetTypes.Request());
    }

    [HttpGet("states")]
    public Task<List<LookupDto>> GetStates()
    {
        return _mediator.Send(new GetStates.Request());
    }

    [HttpPost("elementTypes")]
    public Task AddType([FromBody] AddType.Request request)
    {
        return _mediator.Send(request);
    }

    [HttpPost("states")]
    public Task AddState([FromBody] AddState.Request request)
    {
        return _mediator.Send(request);
    }

    [HttpPut("elementTypes")]
    public Task UpdateType([FromBody] UpdateType.Request request)
    {
        return _mediator.Send(request);
    }

    [HttpPut("states")]
    public Task UpdateState([FromBody] UpdateState.Request request)
    {
        return _mediator.Send(request);
    }

    [HttpDelete("elementTypes")]
    public Task RemoveType([FromBody] RemoveType.Request request)
    {
        return _mediator.Send(request);
    }

    [HttpDelete("states")]
    public Task RemoveState([FromBody] RemoveState.Request request)
    {
        return _mediator.Send(request);
    }
}
