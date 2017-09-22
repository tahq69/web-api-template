namespace Crip.Samples.Tests.Controllers
{
    using Crip.Samples.Controllers;
    using Crip.Samples.Models.User;
    using Crip.Samples.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading.Tasks;

    [TestClass]
    public class AuthControllerTests
    {
        private AuthController ctrl;

        protected TestSubstitutes Substitute { get; private set; }

        /// <summary>
        /// Sets up method tests.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            this.Substitute = new TestSubstitutes();

            var ctx = this.Substitute.Context();
            var svc = new UserService()
            {
                Context = ctx,
                SecurityService = NSubstitute.Substitute.For<ISecurityService>(),
                TokenService = NSubstitute.Substitute.For<ITokenService>(),
            };

            this.ctrl = new AuthController
            {
                UserService = svc,
                Context = ctx,
            };
        }

        [TestMethod]
        public async Task Test_ApiAuth_CanGetRegisteretUserDetails()
        {
            var user = await this.ctrl.Login(new Credentials
            {
                Username = TestData.UserHarley.Username,
                Password = "Password_3",
            });

            Assert.IsNotNull(
                user,
                "Could not get user with valid credentials.");

            Assert.AreEqual(
                TestData.UserHarley.Email,
                user.Email,
                "Requested user email is not equal to returned one.");
        }
    }
}
