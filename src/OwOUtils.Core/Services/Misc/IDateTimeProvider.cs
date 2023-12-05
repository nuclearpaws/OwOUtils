namespace OwOUtils.Core.Services.Misc;

public interface IDateTimeProvider
{
    DateTimeOffset Now { get; }
}
