using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Services.Windows;
using MediatR;

namespace INTUS.SalesManager.Application.Windows;

public static class RemoveWindow
{
    public class Request : WindowDto, IRequest<Unit>
    {
    }

    public class Handler : IRequestHandler<Request, Unit>
    {
        private readonly IWindowService _service;

        public Handler(IWindowService service)
        {
            _service = service;
        }

        public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
        {
            await _service.RemoveWindow(request, cancellationToken);
            return Unit.Value;
        }
    }
}
