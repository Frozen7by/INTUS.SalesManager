namespace INTUS.SalesManager.Common.Models;

public class SubElementDto
{
    public long Id { get; set; }

    public LookupDto ElementType { get; set; }

    public int Index { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }
}

