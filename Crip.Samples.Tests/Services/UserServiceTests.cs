namespace Crip.Samples.Tests.Services
{
    using Crip.Samples.Models.User;
    using Crip.Samples.Services;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Threading.Tasks;

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
            this.Substitute = new TestSubstitutes();

            this.svc = new UserService
            {
                Context = this.Substitute.Context()
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
        }

        [TestMethod]
        public async Task Test_User_RegisterShouldEncriptPassword()
        {
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

            Assert.AreNotEqual(
                "Password_1", inserted.Password,
                "Method 'Register' should encrypt password before insert to " +
                "database");
        }
    }
}
