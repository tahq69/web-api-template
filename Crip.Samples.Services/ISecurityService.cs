namespace Crip.Samples.Services
{
    /// <summary>
    /// Security service contract.
    /// </summary>
    public interface ISecurityService
    {
        /// <summary>
        /// Encrypts the specified plain text.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <param name="passPhrase">The pass phrase.</param>
        /// <returns>Encrypted text.</returns>
        string Encrypt(string plainText, string passPhrase);

        /// <summary>
        /// Decrypts the specified cipher text.
        /// </summary>
        /// <param name="cipherText">The cipher text.</param>
        /// <param name="passPhrase">The pass phrase.</param>
        /// <returns>Decrypted text.</returns>
        string Decrypt(string cipherText, string passPhrase);

        /// <summary>
        /// Hashes the specified plain text.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <param name="passPhrase">The pass phrase.</param>
        /// <returns>Hashed text.</returns>
        string Hash(string plainText, string passPhrase);

        /// <summary>
        /// Determines whether is [hash text] is equals to the specified
        /// [plain text].
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <param name="hashText">The hash text.</param>
        /// <param name="passPhrase">The pass phrase.</param>
        /// <returns>
        /// <c>true</c> if [hash text] is equals to the specified [plain text];
        /// otherwise, <c>false</c>.
        /// </returns>
        bool IsHashEquals(string plainText, string hashText, string passPhrase);
    }
}
