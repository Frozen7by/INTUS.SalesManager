using FluentValidation;
using INTUS.SalesManager.Domain.Models.Lookups;
using INTUS.SalesManager.Domain.Services.Lookups;
using INTUS.SalesManager.Domain.Services.SubElements;

namespace INTUS.SalesManager.Application.Lookups.Validators;

public class RemoveTypeValidator : AbstractValidator<RemoveType.Request>
{
    public RemoveTypeValidator(ILookupService<ElementType> service, ISubElementService subElementService)
    {
        RuleFor(it => it)
            .SetValidator(new TypeIdValidator(service))
            .DependentRules(() =>
            {
                RuleFor(it => it.Id)
                    .MustAsync(async (it, token) => !await subElementService.IsElementTypeUsed(it, token));
            });
    }
}
