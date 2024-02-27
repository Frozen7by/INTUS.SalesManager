using INTUS.SalesManager.Application.SubElements;
using INTUS.SalesManager.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace INTUS.SalesManager.Api.Web.Controllers;

[ApiController]
[Route("/api/v1/subElements")]
public class SubElementsController : Controller
{
    private readonly IMediator _mediator;

    public SubElementsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public Task<List<SubElementDto>> GetSubElements()
    {
        return _mediator.Send(new GetSubElements.Request());
    }

    [HttpGet("{id}")]
    public Task<SubElementDto> GetSubElement([FromRoute] GetSubElement.Request request)
    {
        return _mediator.Send(request);
    }

    [HttpPost]
    public Task AddSubElement([FromBody] AddSubElement.Request request)
    {
        return _mediator.Send(request);
    }

    [HttpPut]
    public Task UpdateSubElement([FromBody] UpdateSubElement.Request request)
    {
        return _mediator.Send(request);
    }

    [HttpDelete("{id}")]
    public Task RemoveSubElement([FromRoute] RemoveSubElement.Request request)
    {
        return _mediator.Send(request);
    }
}
