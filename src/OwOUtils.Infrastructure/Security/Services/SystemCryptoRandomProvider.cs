using System.Security.Cryptography;
using OwOUtils.Core.Services.Security;

namespace OwOUtils.Infrastructure.Security.Services;

internal sealed class SystemCryptoRandomProvider
    : ICryptoRandomProvider
{
    public int GetRandomInt(
        int min = int.MinValue,
        int max = int.MaxValue)
    {
        var randomInt = RandomNumberGenerator.GetInt32(min, max);
        return randomInt;
    }

    public byte[] GetRandomBytes(int count)
    {
        var randomBytes = RandomNumberGenerator.GetBytes(count);
        return randomBytes;
    }
}
