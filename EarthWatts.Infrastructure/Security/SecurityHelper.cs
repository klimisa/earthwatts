using System;
using System.Security.Cryptography;

namespace EarthWatts.Infrastructure.Security
{
    public class SecurityHelper
    {
        public const int SALT_LENGTH_LIMIT = 32;

        public static string GetSalt(int maximumSaltLength = SALT_LENGTH_LIMIT)
        {
            var salt = new byte[maximumSaltLength];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }
    }
}