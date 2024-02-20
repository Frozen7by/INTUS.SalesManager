using System.ComponentModel.DataAnnotations;
using INTUS.SalesManager.Common.Constants;
using INTUS.SalesManager.Domain.Models.Common;
using INTUS.SalesManager.Domain.Models.Orders;
using INTUS.SalesManager.Domain.Models.SubElements;

namespace INTUS.SalesManager.Domain.Models.Windows;

public class Window : BaseEntity
{
    public long OrderId { get; set; }

    public required Order Order { get; set; }

    [MaxLength(FieldConstants.MaxFieldLength)]
    public required string Name { get; set; }

    public int Quantity { get; set; }

    public List<SubElement> SubElements { get; set; } = [];
}
