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

    public static TLookup ToBaseLookup<TLookup>(this LookupDto lookup)
        where TLookup : BaseLookup, new()
    {
        return new TLookup
        {
            Id = lookup.Id,
            Text = lookup.Text,
        };
    }
}
