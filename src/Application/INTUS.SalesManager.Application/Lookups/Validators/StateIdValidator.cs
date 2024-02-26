using FluentValidation;
using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Models.Lookups;
using INTUS.SalesManager.Domain.Services.Lookups;

namespace INTUS.SalesManager.Application.Lookups.Validators;

public class StateIdValidator : AbstractValidator<LookupDto>
{
    public StateIdValidator(ILookupService<State> service)
    {
        RuleFor(it => it.Id)
            .NotEmpty()
            .MustAsync(async (it, token) => (await service.Get(it, token)) != null);
    }
}
