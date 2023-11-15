using System.Security.Cryptography;
using OwOUtils.Shared.Services;

namespace OwOUtils.Infrastructure.Security;

internal sealed class SystemCryptoRandomProvider
    : ICryptoRandomProvider
{
    public byte[] GetBytes(int count)
    {
        var bytes = RandomNumberGenerator.GetBytes(count);
        return bytes;
    }
}
