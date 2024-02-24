namespace INTUS.SalesManager.Common.Models;

public class OrderDto
{
    public long Id { get; set; }

    public string Name { get; set; }

    public LookupDto State { get; set; }
}
