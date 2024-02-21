namespace INTUS.SalesManager.Common.Models;

public  class WindowDto
{
    public long Id { get; set; }

    public string Name { get; set; }

    public int Quantity { get; set; }

    public List<SubElementDto> SubElements { get; set; }

    public int TotalSubElements => SubElements.Count;
}
