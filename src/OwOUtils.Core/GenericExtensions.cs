using System.Text.Json;

namespace OwOUtils.Core;

public static class GenericExtensions
{
    public static string ToJson<TSource>(
        this TSource source)
        where TSource : notnull
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };
        var json = JsonSerializer.Serialize(
            source, source.GetType(), options);
        return json;
    }
}
