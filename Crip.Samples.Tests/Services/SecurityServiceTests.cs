namespace Crip.Samples.Tests.Services
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Crip.Samples.Services;

    [TestClass]
    public class SecurityServiceTests
    {
        private ISecurityService svc;

        /// <summary>
        /// Sets up method tests.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            this.svc = new SecurityService();
        }

        [TestMethod]
        public void Test_Security_EncryptsText()
        {
            var chiper = this.svc.Encrypt("text", "salt");

            Assert.IsFalse(
                string.IsNullOrWhiteSpace(chiper),
                "Encrypted text is not created");

            Assert.AreNotEqual(
                "text", chiper,
                "Encrypted text is equal to original one");
        }

        [TestMethod]
        public void Test_Security_CorrectlyDecryptsText()
        {
            var chiper = this.svc.Encrypt("text", "salt");
            var decrypted = this.svc.Decrypt(chiper, "salt");

            Assert.AreEqual(
                "text", decrypted,
                "Decrypted text is not equal to original");
        }

        [TestMethod]
        public void Test_Security_CouldNotDecryptWithIncorrectSalt()
        {
            var chiper = this.svc.Encrypt("text", "salt");
            var decrypted = this.svc.Decrypt(chiper, "sals");

            Assert.AreNotEqual(
                "text", decrypted,
                "Decrypted text is equal to original when incorrect salt provided");
        }

        [TestMethod]
        public void Test_Security_HashesText()
        {
            var hash = this.svc.Hash("text", "salt");

            Assert.IsFalse(
                string.IsNullOrWhiteSpace(hash),
                "Hashed text is not created");

            Assert.AreNotEqual(
                "text", hash,
                "Hashed text is equal to original one");
        }

        [TestMethod]
        public void Test_Security_CanCompareHashedText()
        {
            var hash = this.svc.Hash("text", "salt");

            Assert.IsTrue(
                this.svc.IsHashEquals("text", hash, "salt"),
                "Could not compare equal hash texts");
        }

        [TestMethod]
        public void Test_Security_CanCompareDifferentlyHashedText()
        {
            var hash = this.svc.Hash("text", "salt");

            Assert.IsFalse(
                this.svc.IsHashEquals("text2", hash, "salt"),
                "Could compare non equal hash texts");
        }

        [TestMethod]
        public void Test_Security_GeneratesDifferentHashes()
        {
            var hash = this.svc.Hash("text", "salt");
            var newHash = this.svc.Hash("text", "salt");

            Assert.AreNotEqual(
                hash, newHash,
                "Creates equal hashes for single string");
        }
    }
}
