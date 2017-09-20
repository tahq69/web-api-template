namespace Crip.Samples.Tests.Services
{
    using Crip.Samples.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using NSubstitute;
    using System;

    /// <summary>
    /// Token service tests.
    /// </summary>
    [TestClass]
    public class TokenServiceTests
    {
        private ITokenService svc;
        private ISecurityService security;

        /// <summary>
        /// Sets up method tests.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            // This tests includes SecurityService as it is impossible to test
            // functionality on fake data.
            this.svc = new TokenService {
                SecuritySvc = new SecurityService()
            };
        }

        [TestMethod]
        public void Test_Token_CreatesNewToken()
        {
            var (token, guid) = this.svc.New("name");

            Assert.IsFalse(
                string.IsNullOrWhiteSpace(token),
                "Token is not created");
        }

        [TestMethod]
        public void Test_Token_CreatesNonExpiredToken()
        {
            var (token, guid) = this.svc.New("name");
            var isExpired = this.svc.IsExpired(token);


            Assert.IsFalse(isExpired, "Token is expired after creation");
        }

        [TestMethod]
        public void Test_Token_CreatesTokenWithTTLGreaterThanA23h()
        {
            var (token, guid) = this.svc.New("name");
            var ttl = this.svc.TokenTimeToLive(token);

            Assert.IsTrue(
                ttl.TotalHours > 23,
                "Token time to live by default is less than 23 hours");
        }

        [TestMethod]
        public void Test_Token_CreatesTokenWithCustomTTL()
        {
            var (token, guid) = this.svc.New("name", 59);
            var ttl = this.svc.TokenTimeToLive(token);

            Assert.IsTrue(
                ttl.TotalHours < 1 && ttl.TotalMinutes > 58,
                "Token time to live is not in range of expected values");
        }

        [TestMethod]
        public void Test_Token_CanGetGuidFromCreatedToken()
        {
            var (token, guid) = this.svc.New("name");
            var resolvedGuid = this.svc.GetGuid(token);

            Assert.AreEqual(
                guid, resolvedGuid,
                "Extracted guid is not equal to created one");
        }
    }
}
