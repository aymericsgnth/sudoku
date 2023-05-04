using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    /*
     * Aymeric Siegenthaler
     * 2b
     * SecretHasher class
     * V1
     */
    public static class SecretHasher
    {
        /// <summary>
        /// Hash a password
        /// source : ChatGPT
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string Hash(string password)
        {
            byte[] salt = new byte[16];
            // random bytes
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] combinedBytes = new byte[passwordBytes.Length + salt.Length];
            // copy passwordBytes to combinedBytes
            Buffer.BlockCopy(passwordBytes, 0, combinedBytes, 0, passwordBytes.Length);
            // concat Bytes of salt at the end
            Buffer.BlockCopy(salt, 0, combinedBytes, passwordBytes.Length, salt.Length);

            using (var sha256 = new SHA256Managed())
            {
                byte[] hash = sha256.ComputeHash(combinedBytes);
                byte[] hashBytes = new byte[hash.Length + salt.Length];
                Buffer.BlockCopy(hash, 0, hashBytes, 0, hash.Length);
                Buffer.BlockCopy(salt, 0, hashBytes, hash.Length, salt.Length);
                return Convert.ToBase64String(hashBytes);
            }
        }
        /// <summary>
        /// Verify a hashed password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="hashedPassword"></param>
        /// <returns></returns>
        public static bool Verify(string password, string hashedPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);
            byte[] salt = new byte[16];
            Buffer.BlockCopy(hashBytes, hashBytes.Length - salt.Length, salt, 0, salt.Length);

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] combinedBytes = new byte[passwordBytes.Length + salt.Length];
            Buffer.BlockCopy(passwordBytes, 0, combinedBytes, 0, passwordBytes.Length);
            Buffer.BlockCopy(salt, 0, combinedBytes, passwordBytes.Length, salt.Length);

            using (var sha256 = new SHA256Managed())
            {
                byte[] hash = sha256.ComputeHash(combinedBytes);
                for (int i = 0; i < hash.Length; i++)
                {
                    if (hash[i] != hashBytes[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
