using System;
using System.Security.Cryptography;

namespace BookMentalCareCore.BLL
{
    public class PasswordHasher
    {
        public string Hash { get; private set; }
        public string Salt { get; private set; }

        public PasswordHasher(string password)
        {
            GenerateSalt();
            Hash = GenerateHash(Salt, password);
        }

        private static string GenerateHash(string salt, string password)
        {
            var saltBytes = Convert.FromBase64String(salt);
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000))
            {
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));
            }
        }

        private void GenerateSalt()
        {
            var saltBytes = new byte[32];
            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetNonZeroBytes(saltBytes);
            }

            Salt = Convert.ToBase64String(saltBytes);
        }

        public static bool CheckPassword(string salt, string hash, string password)
        {
            return hash == GenerateHash(salt, password);
        }
    }
}
