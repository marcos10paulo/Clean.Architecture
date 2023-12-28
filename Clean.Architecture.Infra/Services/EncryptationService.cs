using Clean.Architecture.Application.Interfaces.Security;
using System.Text;

namespace Clean.Architecture.Infra.Services
{
    public class EncryptationService : IEncryptationService
    {
        public static readonly string KEY = "Texto";

        public string Decrypt(string value, string? key = null)
        {
            string sNewValue = "";
            string newKey = key ?? KEY;

            for (int i = 0; i < newKey.Length; i++)
            {
                sNewValue = "";
                for (int j = 0; j < value.Length; j++)
                    sNewValue += Convert.ToChar((Convert.ToInt32(newKey[i])) ^ (Convert.ToInt32(value[j])));
                value = sNewValue;
            }

            return sNewValue;
        }


        public string DecryptFromBase64(string value, string? key = null)
        {
            string newKey = key ?? KEY;
            return Decrypt(
                    Encoding.UTF8.GetString(Convert.FromBase64String(value)),
                    newKey
                );
        }

        public string Encrypt(string value, string? key = null)
        {
            string sNewValue = "";
            string newKey = key ?? KEY;

            for (int i = 0; i < newKey.Length; i++)
            {
                sNewValue = "";
                for (int j = 0; j < value.Length; j++)
                    sNewValue += Convert.ToChar((Convert.ToInt32(newKey[i])) ^ (Convert.ToInt32(value[j])));
                value = sNewValue;
            }

            return sNewValue;
        }

        public string GetMD5(string s)
        {

            byte[] inputBytes = Encoding.ASCII.GetBytes(s);
            byte[] hash = System.Security.Cryptography.MD5.HashData(inputBytes);

            StringBuilder sb = new();
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("X2"));
            }
            return (sb.ToString().ToUpper());
        }
    }
}
