using System;
using System.Security.Cryptography;
using System.Text;

namespace Heat.Application.Common
{
    public static class SHA2Hasher
    {
        public static string ComputeHash(string data)
        {
            return BitConverter.ToString(
                SHA256.Create().ComputeHash(
                    Encoding.UTF8.GetBytes(data)
                )
            );
        }
    }
}
