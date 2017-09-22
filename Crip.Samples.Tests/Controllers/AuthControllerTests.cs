namespace Crip.Samples.Tests.Controllers
{
    using Crip.Samples.Controllers;
    using Crip.Samples.Models.User;
    using Crip.Samples.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NSubstitute;
    using System.Threading.Tasks;

    [TestClass]
    public class AuthControllerTests
    {
        private AuthController ctrl;

        protected TestSubstitutes Sub { get; private set; }

        /// <summary>
        /// Sets up method tests.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            this.Sub = new TestSubstitutes();

            var ctx = this.Sub.Context();
            var svc = Substitute.For<IUserService>();

            this.ctrl = new AuthController
            {
                UserService = svc,
                Context = ctx,
            };
        }

        [TestMethod]
        public async Task Test_ApiAuth_CanGetRegisteretUserDetails()
        {
            var credentials = new Credentials
            {
                Username = "Username",
                Password = "Password",
            };

            this.ctrl.UserService
                .Login(credentials)
                .Returns(TestData.UserDetailsHarley);

            var user = await this.ctrl.Login(credentials);

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
