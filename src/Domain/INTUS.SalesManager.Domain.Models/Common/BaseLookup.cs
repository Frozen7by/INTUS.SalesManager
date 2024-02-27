using System.ComponentModel.DataAnnotations;
using INTUS.SalesManager.Common.Constants;

namespace INTUS.SalesManager.Domain.Models.Common;

public class BaseLookup : IHasId
{
    public long Id { get; set; }

    [MaxLength(FieldConstants.MaxLookupTextLength)]
    public string Text { get; set; }
}
