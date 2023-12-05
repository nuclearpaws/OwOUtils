using OwOUtils.Core.Services.Misc;

namespace OwOUtils.Infrastructure.Misc.Services;

public sealed class SystemDateTimeProvider
    : IDateTimeProvider
{
    public DateTimeOffset Now => DateTimeOffset.Now;
}
