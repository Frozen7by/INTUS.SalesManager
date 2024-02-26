using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Services.Windows;
using MediatR;

namespace INTUS.SalesManager.Application.Windows;

public static class GetWindow
{
    public class Request : IRequest<WindowDto>
    {
        public long Id { get; set; }
    }

    public class Handler : IRequestHandler<Request, WindowDto>
    {
        private readonly IWindowService _service;

        public Handler(IWindowService service)
        {
            _service = service;
        }

        public Task<WindowDto> Handle(Request request, CancellationToken cancellationToken)
        {
            return _service.GetWindow(request.Id, cancellationToken);
        }
    }
}
