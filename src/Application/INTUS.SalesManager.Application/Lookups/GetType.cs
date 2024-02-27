using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Models.Lookups;
using INTUS.SalesManager.Domain.Services.Lookups;
using MediatR;

namespace INTUS.SalesManager.Application.Lookups;

public static class GetType
{
    public class Request : IRequest<LookupDto>
    {
        public long Id { get; set; }
    }

    public class Handler : IRequestHandler<Request, LookupDto>
    {
        private readonly ILookupService<State> _service;

        public Handler(ILookupService<State> service)
        {
            _service = service;
        }

        public Task<LookupDto> Handle(Request request, CancellationToken cancellationToken)
        {
            return _service.Get(request.Id, cancellationToken)!;
        }
    }
}
