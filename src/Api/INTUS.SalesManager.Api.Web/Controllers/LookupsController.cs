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
}
