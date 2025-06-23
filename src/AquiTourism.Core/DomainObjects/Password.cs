using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace AquiTourism.Core.DomainObjects
{
    public class Password
    {
        public string Hash { get; }
        public string Salt { get; }

        public Password(string password, string confirmPassword)
        {
            if (password != confirmPassword)
                throw new ArgumentException("As senhas não combinam.");

            if (!HasNumber(password))
                throw new ArgumentException("A senha precisa conter pelo menos um número");

            if (!HasUppercase(password))
                throw new ArgumentException("A senha precisa ter pelo menos uma letra maiúscula");

            Salt = GenerateSalt();
            Hash = HashPassword(password, Salt);
        }

        private static bool HasNumber(string input) =>
            Regex.IsMatch(input, @"\d");

        private static bool HasUppercase(string input) =>
            Regex.IsMatch(input, @"[A-Z]");

        private static string GenerateSalt()
        {
            var saltBytes = new byte[16];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        private static string HashPassword(string password, string salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 100_000, HashAlgorithmName.SHA256);
            var hash = pbkdf2.GetBytes(32);
            return Convert.ToBase64String(hash);
        }

        public static bool Verify(string password, string hash, string salt)
        {
            var hashToCompare = HashPassword(password, salt);
            return hashToCompare == hash;
        }
    }
}