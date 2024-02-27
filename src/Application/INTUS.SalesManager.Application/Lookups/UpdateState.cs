using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Models.Lookups;
using INTUS.SalesManager.Domain.Services.Lookups;
using MediatR;

namespace INTUS.SalesManager.Application.Lookups;
public static class UpdateState
{
    public class Request : LookupDto, IRequest<Unit>
    {
    }

    public class Handler : IRequestHandler<Request, Unit>
    {
        private readonly ILookupService<State> _service;

        public Handler(ILookupService<State> service)
        {
            _service = service;
        }

        public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
        {
            await _service.Update(request, cancellationToken);
            return Unit.Value;
        }
    }
}
