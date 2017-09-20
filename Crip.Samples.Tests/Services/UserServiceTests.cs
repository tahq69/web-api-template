namespace Crip.Samples.Tests.Services
{
    using Crip.Samples.Models.User;
    using Crip.Samples.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Threading.Tasks;
    using NSubstitute;

    /// <summary>
    /// User service tests.
    /// </summary>
    [TestClass]
    public partial class UserServiceTests
    {
        private IUserService svc;

        protected TestSubstitutes Substitute { get; private set; }

        /// <summary>
        /// Sets up method tests.
        /// </summary>
        [TestInitialize]
        public void SetUp()
        {
            var securityService = NSubstitute.Substitute.For<ISecurityService>();
            var tokenService = NSubstitute.Substitute.For<ITokenService>();

            this.Substitute = new TestSubstitutes();
            this.svc = new UserService
            {
                Context = this.Substitute.Context(),
                SecurityService = securityService,
                TokenService = tokenService,
            };
        }

        /// <summary>
        /// Tests user service, all should return collection of users.
        /// </summary>
        [TestMethod]
        public async Task Test_User_AllShouldReturnCollectionOfUsers()
        {
            var result = await this.svc.All();

            Assert.IsNotNull(
                result,
                "Method 'All' returned null instead of collection");

            Assert.IsTrue(
                result.Count() > 0,
                "Result count should be greater than a 0");
        }

        /// <summary>
        /// Tests user service, find should return record with correct
        /// identifier.
        /// </summary>
        [TestMethod]
        public async Task Test_User_FindShouldReturnRecordWithCorrectId()
        {
            var result = await this.svc.Find(2);

            Assert.IsNotNull(
                result,
                "Method 'Find' returned null instead of record");

            Assert.AreEqual(
                2, result.Id,
                "Method 'Find' returned incorrect record");
        }

        [TestMethod]
        public async Task Test_User_RegisterShouldCreateUser()
        {
            var result = await this.svc.Register(new Registration
            {
                Email = "email_1@example.com",
                Name = "Name_1",
                Password = "Password_1",
                Surname = "Surname_1",
                Username = "Username_1",
            });

            Assert.IsNotNull(
                result,
                "Method 'Register' returned null instead of record");

            Assert.AreEqual(
                1, this.Substitute.Users.Inserted.Count,
                "Method 'Register' should insert single user record to DB");

            var inserted = this.Substitute.Users.Inserted[0];

            Assert.AreEqual(
                "email_1@example.com", inserted.Email,
                "Method 'Register' should insert model email");

            await this.svc.Context.Received().SaveChangesAsync();
        }

        [TestMethod]
        public async Task Test_User_RegisterShouldEncriptPassword()
        {
            this.svc.SecurityService
                .Hash("Password_2")
                .Returns("Hashed_Password_2");

            var result = await this.svc.Register(new Registration
            {
                Email = "email_2@example.com",
                Name = "Name_2",
                Password = "Password_2",
                Surname = "Surname_2",
                Username = "Username_2",
            });

            var inserted = this.Substitute.Users.Inserted[0];

            Assert.IsFalse(
                string.IsNullOrWhiteSpace(inserted.Password),
                "Method 'Register' should not insert empty password");

            Assert.AreEqual(
                "Hashed_Password_2", inserted.Password,
                "Method 'Register' should hash password before insert to " +
                "database");
        }

        [TestMethod]
        public async Task Test_User_RegisterShouldReturnUserDetailsModel()
        {
            var result = await this.svc.Register(new Registration
            {
                Email = "email_3@example.com",
                Name = "Name_3",
                Password = "Password_3",
                Surname = "Surname_3",
                Username = "Username_3",
            });

            var inserted = this.Substitute.Users.Inserted[0];

            Assert.AreEqual(
                inserted.Email, result.Email,
                "Inserted Email is not equal to returned one");

            Assert.AreEqual(
                inserted.Name, result.Name,
                "Inserted Name is not equal to returned one");

            Assert.AreEqual(
                inserted.Surname, result.Surname,
                "Inserted Surname is not equal to returned one");

            Assert.AreEqual(
                inserted.Username, result.Username,
                "Inserted email is not equal to returned one");
        }

        [TestMethod]
        public async Task Test_User_LoginShouldReturnUserDetailsModel()
        {
            this.svc.SecurityService
                .IsHashEquals("Password_1", "Password_1_Hash")
                .Returns(true);

            var result = await this.svc.Login(new Credentials
            {
                Username = "TomSoup",
                Password = "Password_1",
            });

            Assert.AreEqual(
                "TomSoup", result.Username,
                "Could not get correct user");
        }

        [TestMethod]
        public async Task Test_User_LoginShouldReturnUserDetailsModelByEmail()
        {
            this.svc.SecurityService
                .IsHashEquals("Password_1", "Password_1_Hash")
                .Returns(true);

            this.svc.TokenService
                .New("TomSoup@example.com")
                .Returns(("token", "guid"));

            var result = await this.svc.Login(new Credentials
            {
                Username = "TomSoup@example.com",
                Password = "Password_1",
            });

            Assert.AreEqual(
                "TomSoup", result.Username,
                "Could not get correct user");
        }

        [TestMethod]
        public async Task Test_User_LoginShouldReturnNullOnIncorrectUsername()
        {
            var result = await this.svc.Login(new Credentials
            {
                Username = "TomSoup@example",
                Password = "Password_1",
            });

            Assert.IsNull(result, "On incorrect input can get user");
        }

        [TestMethod]
        public async Task Test_User_LoginShouldReturnNullOnIncorrectPassword()
        {
            this.svc.SecurityService
                .IsHashEquals("Password_2", "Password_1_Hash")
                .Returns(false);

            this.svc.TokenService
                .New("TomSoup@example.com")
                .Returns(("token", "guid"));

            var result = await this.svc.Login(new Credentials
            {
                Username = "TomSoup@example.com",
                Password = "Password_2",
            });

            Assert.IsNull(result, "On incorrect input can get user");
        }
    }
}
