using INTUS.SalesManager.Application.Windows;
using INTUS.SalesManager.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace INTUS.SalesManager.Api.Web.Controllers;

[ApiController]
[Route("/api/v1/windows")]
public class WindowsController : Controller
{
    private readonly IMediator _mediator;

    public WindowsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public Task<List<WindowListDto>> GetWindows()
    {
        return _mediator.Send(new GetWindows.Request());
    }

    [HttpGet("{id}")]
    public Task<WindowDto> GetWindow([FromRoute] GetWindow.Request request)
    {
        return _mediator.Send(request);
    }

    [HttpPost]
    public Task AddWindow([FromBody] AddWindow.Request request)
    {
        return _mediator.Send(request);
    }

    [HttpPut]
    public Task UpdateWindow([FromBody] UpdateWindow.Request request)
    {
        return _mediator.Send(request);
    }

    [HttpDelete("{id}")]
    public Task RemoveWindow([FromRoute] RemoveWindow.Request request)
    {
        return _mediator.Send(request);
    }
}
