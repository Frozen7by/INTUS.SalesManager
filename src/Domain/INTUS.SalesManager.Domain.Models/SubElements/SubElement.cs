using INTUS.SalesManager.Domain.Models.Common;
using INTUS.SalesManager.Domain.Models.Lookups;
using INTUS.SalesManager.Domain.Models.Windows;

namespace INTUS.SalesManager.Domain.Models.SubElements;

public class SubElement : BaseEntity
{
    public long WindowId { get; set; }

    public required Window Window { get; set; }

    public long ElementTypeId { get; set; }

    public required ElementType ElementType { get; set; }

    public int Index { get; set; }
    
    public int Width { get; set; }

    public int Height { get; set; }
}
