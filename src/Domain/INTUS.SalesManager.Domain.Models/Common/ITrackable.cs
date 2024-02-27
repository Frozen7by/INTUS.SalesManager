namespace INTUS.SalesManager.Domain.Models.Common;

public interface ITrackable
{
    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }
}
