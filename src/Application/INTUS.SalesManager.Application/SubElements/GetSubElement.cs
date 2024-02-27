using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Services.SubElements;
using MediatR;

namespace INTUS.SalesManager.Application.SubElements;

public static class GetSubElement
{
    public class Request : IRequest<SubElementDto>
    {
        public long Id { get; set; }
    }

    public class Handler : IRequestHandler<Request, SubElementDto>
    {
        private readonly ISubElementService _service;

        public Handler(ISubElementService service)
        {
            _service = service;
        }

        public Task<SubElementDto> Handle(Request request, CancellationToken cancellationToken)
        {
            return _service.GetSubElement(request.Id, cancellationToken);
        }
    }
}
