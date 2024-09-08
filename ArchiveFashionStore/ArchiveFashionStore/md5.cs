using System;
using System.Security.Cryptography;
using System.Text;

namespace ArchiveFashionStore
{
    internal class md5
    {
        public static string GetHashedPassword(string password)
        {
            MD5 _md5 = MD5.Create();
            byte[] b = Encoding.ASCII.GetBytes(password);
            byte[] hash = _md5.ComputeHash(b);
            StringBuilder string_builder = new StringBuilder();
            foreach (byte a in hash)
            {
                string_builder.Append(a.ToString("X2"));
            }
            return Convert.ToString(string_builder);
        }
    }
}
