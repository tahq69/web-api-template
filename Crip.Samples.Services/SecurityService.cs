namespace Crip.Samples.Services
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    /// <summary>
    /// Security service.
    /// </summary>
    /// <seealso cref="Crip.Samples.Services.ISecurityService" />
    public class SecurityService : ISecurityService
    {
        // This constant is used to determine the key size of the encryption
        // algorithm in bits. We divide this by 8 within the code below to get
        // the equivalent number of bytes.
        private const int Keysize = 256;

        // This constant determines the number of iterations for the password
        // bytes generation function.
        private const int DerivationIterations = 1000;

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <param name="passPhrase">The pass phrase.</param>
        /// <returns>
        /// Decrypted text.
        /// </returns>
        public string Decrypt(string cipherText, string passPhrase)
        {
            // Get the complete stream of bytes that represent:
            // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);

            // Get the saltbytes by extracting the first 32 bytes from the
            // supplied cipherText bytes.
            var saltStringBytes = cipherTextBytesWithSaltAndIv
                .Take(Keysize / 8)
                .ToArray();

            // Get the IV bytes by extracting the next 32 bytes from the
            // supplied cipherText bytes.
            var ivStringBytes = cipherTextBytesWithSaltAndIv
                .Skip(Keysize / 8)
                .Take(Keysize / 8)
                .ToArray();

            // Get the actual cipher text bytes by removing the first 64 bytes
            // from the cipherText string.
            var cipherTextBytes = cipherTextBytesWithSaltAndIv
                .Skip((Keysize / 8) * 2)
                .Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2))
                .ToArray();
            try
            {
                using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
                {
                    var keyBytes = password.GetBytes(Keysize / 8);
                    using (var symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.BlockSize = 256;
                        symmetricKey.Mode = CipherMode.CBC;
                        symmetricKey.Padding = PaddingMode.PKCS7;

                        using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            var plainTextBytes = new byte[cipherTextBytes.Length];
                            var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

                            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                        }
                    }
                }
            }
            catch (Exception)
            {
                // If cant decode, just return empty string
                return string.Empty;
            }
        }

        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <param name="passPhrase">The pass phrase.</param>
        /// <returns>
        /// Encrypted text.
        /// </returns>
        public string Encrypt(string plainText, string passPhrase)
        {
            // Salt and IV is randomly generated each time, but is preprended
            // to encrypted cipher text so that the same Salt and IV values can
            // be used when decrypting.
            var saltStringBytes = this.Generate256BitsOfRandomEntropy();
            var ivStringBytes = this.Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;

                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    using (var memoryStream = new MemoryStream())
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cryptoStream.FlushFinalBlock();

                        // Create the final bytes as a concatenation of
                        // the random salt bytes, the random iv bytes and the cipher bytes.
                        var cipherTextBytes = saltStringBytes;
                        cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                        cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();

                        return Convert.ToBase64String(cipherTextBytes);
                    }
                }
            }
        }

        /// <summary>
        /// Hashes the specified plain text.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <returns>
        /// Hashed text.
        /// </returns>
        public string Hash(string plainText)
        {
            // Create the salt value with a cryptographic PRNG
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            // Create the Rfc2898DeriveBytes and get the hash value
            var pbkdf2 = new Rfc2898DeriveBytes(plainText, salt, DerivationIterations);
            var hash = pbkdf2.GetBytes(20);

            // Combine the salt and password bytes for later use
            var hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Turn the combined salt+hash into a string for storage
            string textHash = Convert.ToBase64String(hashBytes);

            return textHash;
        }

        /// <summary>
        /// Determines whether is [hash text] is equals to the specified
        /// [plain text].
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <param name="hashText">The hash text.</param>
        /// <returns>
        /// <c>true</c> if [hash text] is equals to the specified [plain text];
        /// otherwise, <c>false</c>.
        /// </returns>
        public bool IsHashEquals(string plainText, string hashText)
        {
            var hashBytes = Convert.FromBase64String(hashText);

            var salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(plainText, salt, DerivationIterations);
            var hash = pbkdf2.GetBytes(20);

            // Compare the results
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }

        private byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                // Fill the array with cryptographically secure random bytes.
                rngCsp.GetBytes(randomBytes);
            }

            return randomBytes;
        }
    }
}
