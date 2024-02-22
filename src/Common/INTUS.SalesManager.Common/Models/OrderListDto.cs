namespace INTUS.SalesManager.Common.Models;

public class OrderListDto
{
    public long Id { get; set; }

    public string Name { get; set; }

    public LookupDto State { get; set; }

    public int Windows { get; set; }
}
