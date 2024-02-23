using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Models.Lookups;
using INTUS.SalesManager.Domain.Services.Lookups;
using MediatR;

namespace INTUS.SalesManager.Application.Lookups;

public static class GetStates
{
    public class Request : IRequest<List<LookupDto>>
    {
    }

    public class Handler : IRequestHandler<Request, List<LookupDto>>
    {
        private readonly ILookupService<State> _service;

        public Handler(ILookupService<State> service)
        {
            _service = service;
        }

        public Task<List<LookupDto>> Handle(Request request, CancellationToken cancellationToken)
        {
            return _service.GetAll(cancellationToken);
        }
    }
}
