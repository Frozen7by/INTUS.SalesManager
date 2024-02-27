namespace INTUS.SalesManager.Infrastructure.Common;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow()
    {
        return DateTime.UtcNow;
    }
}
