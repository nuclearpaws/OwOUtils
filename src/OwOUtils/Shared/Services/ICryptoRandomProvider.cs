namespace OwOUtils.Shared.Services;

public interface ICryptoRandomProvider
{
    byte[] GetBytes(int count);
}
