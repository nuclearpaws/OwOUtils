namespace OwOUtils.Shared.Services;

public static class RandomProviderExtensions
{
    public static int[] GetInts(
        this ICryptoRandomProvider cryptoRandomProvider,
        int count)
    {
        const int size = 4;
        var bytes = cryptoRandomProvider.GetBytes(size * count);
        var int32s = new int[count];
        for (var i = 0; i < count; i++)
            int32s[i] = BitConverter.ToInt32(
                bytes,
                count == 0
                    ? 0
                    : size * count);
        return int32s;
    }
}
