namespace Crip.Samples.Tests
{
    using Crip.Samples.Data;
    using Crip.Samples.Data.Entities;
    using NSubstitute;

    /// <summary>
    /// Tests substitute helpers.
    /// </summary>
    public class TestSubstitutes
    {
        /// <summary>
        /// Gets the users mock data.
        /// </summary>
        public DbSetMock<User> Users { get; private set; }

        /// <summary>
        /// Gets the roles mock data.
        /// </summary>
        public DbSetMock<Role> Roles { get; private set; }

        /// <summary>
        /// Mocks the context.
        /// </summary>
        /// <returns>Mocked database context.</returns>
        public IDatabaseContext Context()
        {
            var context = Substitute.For<IDatabaseContext>();

            this.Users = new DbSetMock<User>(TestData.Users);
            this.Roles = new DbSetMock<Role>(null);

            context.Users.Returns(this.Users.Mock);
            context.Roles.Returns(this.Roles.Mock);

            return context;
        }
    }
}
