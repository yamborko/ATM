using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ATM.Backend.Model.Helpers
{
    public static class HMACHelper
    {
        public static String Hash(String valueString, String algorithmName = "HMACSHA256")
        {
            var provider = HMAC.Create(algorithmName);
            var encoder = Encoding.Unicode;
            var buffer = provider.ComputeHash(encoder.GetBytes(valueString));

            var hash = new StringBuilder();

            for (int i = 0; i < buffer.Length; i++)
            {
                hash.Append(buffer[i].ToString("X2")); // hex format
            }

            return hash.ToString();
        }

    }
}