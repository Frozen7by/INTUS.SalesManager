using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Services.SubElements;
using MediatR;

namespace INTUS.SalesManager.Application.SubElements;

public static class GetSubElements
{
    public class Request : IRequest<List<SubElementDto>>
    {
    }

    public class Handler : IRequestHandler<Request, List<SubElementDto>>
    {
        private readonly ISubElementService _service;

        public Handler(ISubElementService service)
        {
            _service = service;
        }

        public Task<List<SubElementDto>> Handle(Request request, CancellationToken cancellationToken)
        {
            return _service.GetSubElements(cancellationToken);
        }
    }
}
