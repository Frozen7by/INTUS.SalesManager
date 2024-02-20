namespace INTUS.SalesManager.Domain.Models.Common;

public class BaseEntity : IHasId, ITrackable, ISoftDeletable
{
    public long Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }
}
