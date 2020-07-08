using System.Security.Cryptography;
using System.Text;

namespace Nhom2.TMDT.Common.Encryption
{
    public class Encryption
    {
        public string EncryptionMD5(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            byte[] inputBytes = Encoding.ASCII.GetBytes(value);
            byte[] hash = MD5.Create().ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("x2"));
            return sb.ToString();
        }
    }
}
