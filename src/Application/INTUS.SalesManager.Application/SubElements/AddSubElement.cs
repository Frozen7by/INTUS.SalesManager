using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Services.SubElements;
using MediatR;

namespace INTUS.SalesManager.Application.SubElements;

public static class AddSubElement
{
    public class Request : SubElementDto, IRequest<Unit>
    {
    }

    public class Handler : IRequestHandler<Request, Unit>
    {
        private readonly ISubElementService _service;

        public Handler(ISubElementService service)
        {
            _service = service;
        }

        public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
        {
            await _service.AddSubElement(request, cancellationToken);
            return Unit.Value;
        }
    }
}
