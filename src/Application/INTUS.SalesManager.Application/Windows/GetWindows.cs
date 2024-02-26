using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Services.Windows;
using MediatR;

namespace INTUS.SalesManager.Application.Windows;

public static class GetWindows
{
    public class Request : IRequest<List<WindowListDto>>
    {
        public long OrderId { get; set; }
    }

    public class Handler : IRequestHandler<Request, List<WindowListDto>>
    {
        private readonly IWindowService _service;

        public Handler(IWindowService service)
        {
            _service = service;
        }

        public Task<List<WindowListDto>> Handle(Request request, CancellationToken cancellationToken)
        {
            return _service.GetWindows(request.OrderId, cancellationToken);
        }
    }
}
