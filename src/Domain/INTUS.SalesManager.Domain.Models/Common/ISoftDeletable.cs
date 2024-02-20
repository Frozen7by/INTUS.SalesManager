namespace INTUS.SalesManager.Domain.Models.Common;

public interface ISoftDeletable
{
    public DateTime? DeletedDate { get; set; }
}
