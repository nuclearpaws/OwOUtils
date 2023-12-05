using OwOUtils.Core.Services.Security;

namespace OwOUtils.Infrastructure.Security.Services;

internal sealed class AesCryptographer
    : IAesCryptographer
{
    public byte[] Decrypt(byte[] input, byte[] iv)
    {
        throw new NotImplementedException();
    }

    public byte[] Encrypt(byte[] input, byte[] iv)
    {
        throw new NotImplementedException();
    }
}
