using INTUS.SalesManager.Common.Models;
using INTUS.SalesManager.Domain.Models.Common;

namespace INTUS.SalesManager.Domain.Services.Extenstions;

public static class LookupExtensions
{
    public static LookupDto ToLookupDto(this BaseLookup lookup)
    {
        return new LookupDto
        {
            Id = lookup.Id,
            Text = lookup.Text,
        };
    }

    public static BaseLookup ToBaseLookup(this LookupDto lookup)
    {
        return new BaseLookup
        {
            Id = lookup.Id,
            Text = lookup.Text,
        };
    }
}
