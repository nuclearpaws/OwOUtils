namespace OwOUtils.Core.Services.Security;

public interface ICryptoRandomProvider
{
    int GetRandomInt(
        int min = int.MinValue,
        int max = int.MaxValue);

    byte[] GetRandomBytes(int count);
}
