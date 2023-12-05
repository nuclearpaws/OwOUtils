namespace OwOUtils.Core.Services.Security;

public interface IAesCryptographer
{
    byte[] Encrypt(byte[] input, byte[] iv);

    byte[] Decrypt(byte[] input, byte[] iv);
}
