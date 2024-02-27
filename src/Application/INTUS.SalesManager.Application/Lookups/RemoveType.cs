using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Models.Lookups;
using INTUS.SalesManager.Domain.Services.Lookups;
using MediatR;

namespace INTUS.SalesManager.Application.Lookups;

public static class RemoveType
{
    public class Request : LookupDto, IRequest<Unit>
    {
    }

    public class Handler : IRequestHandler<Request, Unit>
    {
        private readonly ILookupService<ElementType> _service;

        public Handler(ILookupService<ElementType> service)
        {
            _service = service;
        }

        public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
        {
            await _service.Remove(request, cancellationToken);
            return Unit.Value;
        }
    }
}
