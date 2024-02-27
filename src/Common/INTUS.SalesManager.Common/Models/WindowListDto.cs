namespace INTUS.SalesManager.Common.Models;

public  class WindowListDto
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string OrderName { get; set; }

    public int Quantity { get; set; }

    public int TotalSubElements { get; set; }
}
