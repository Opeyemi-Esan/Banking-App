using System;
using System.Security.Cryptography;

namespace BankingAppWebApi.Models
{
    public class PasswordHelper
    {
        public static (string hashedPassword, byte[] salt) HashPassword(string password)
        {
            // Generate a salt  
            byte[] salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Hash the password  
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(20);
                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);
                string hashedPassword = Convert.ToBase64String(hashBytes);
                return (hashedPassword, salt);
            }
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Extract the bytes  
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // Hash the password with the same salt  
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(20);
                for (int i = 0; i < 20; i++)
                {
                    if (hashBytes[i + 16] != hash[i])
                    {
                        return false; // Password does not match  
                    }
                }
            }
            return true; // Password matches  
        }
    }
}
