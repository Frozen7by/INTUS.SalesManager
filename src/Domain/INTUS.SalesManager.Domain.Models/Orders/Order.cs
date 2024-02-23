using System.ComponentModel.DataAnnotations;
using INTUS.SalesManager.Common.Constants;
using INTUS.SalesManager.Domain.Models.Common;
using INTUS.SalesManager.Domain.Models.Lookups;
using INTUS.SalesManager.Domain.Models.Windows;

namespace INTUS.SalesManager.Domain.Models.Orders;

public class Order : BaseEntity
{
    [MaxLength(FieldConstants.MaxFieldLength)]
    public required string Name { get; set; }

    public long StateId { get; set; }

    public State State { get; set; }

    public List<Window> Windows { get; set; } = [];
}
