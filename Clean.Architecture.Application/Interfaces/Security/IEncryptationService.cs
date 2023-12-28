namespace Clean.Architecture.Application.Interfaces.Security
{
    public interface IEncryptationService
    {
        string Encrypt(string value, string? key = null);
        string Decrypt(string value, string? key = null);
        string DecryptFromBase64(string value, string? key = null);
        string GetMD5(string value);

    }
}
