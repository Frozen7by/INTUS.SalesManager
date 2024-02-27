using FluentValidation;
using INTUS.SalesManager.Domain.Models.Lookups;
using INTUS.SalesManager.Domain.Services.Lookups;
using INTUS.SalesManager.Domain.Services.Orders;

namespace INTUS.SalesManager.Application.Lookups.Validators;

public class RemoveStateValidator : AbstractValidator<RemoveState.Request>
{
    public RemoveStateValidator(ILookupService<State> service, IOrderService orderService)
    {
        RuleFor(it => it)
            .SetValidator(new StateIdValidator(service))
            .DependentRules(() =>
            {
                RuleFor(it => it.Id)
                    .MustAsync(async (it, token) => !(await orderService.GetOrders(token))
                        .Any(order => order.State.Id == it));
            });
    }
}
