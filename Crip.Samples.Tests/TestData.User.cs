using Crip.Samples.Data.Entities;

namespace Crip.Samples.Tests
{
    /// <summary>
    /// Product entity test data.
    /// </summary>
    public partial class TestData
    {
        /// <summary>
        /// Gets the user: Tom Soup.
        /// </summary>
        public static User UserTom => new User
        {
            Id = 1,
            Name = "Tom",
            Surname = "Soup",
            Email = "TomSoup@example.com",
            Username = "TomSoup",
            Password = "Password_1_Hash",
        };

        /// <summary>
        /// Gets the user: Yo Yo.
        /// </summary>
        public static User UserYo => new User
        {
            Id = 2,
            Name = "Yo",
            Surname = "Yo",
            Email = "YoYo@example.com",
            Username = "YoYo",
            Password = "Password_2_Hash",
        };

        /// <summary>
        /// Gets the product: Harley Hammer.
        /// </summary>
        public static User UserHarley => new User
        {
            Id = 3,
            Name = "Harley",
            Surname = "Hammer",
            Email = "HarleyHammer@example.com",
            Username = "HarleyHammer",
            Password = "Password_3_Hash",
        };

        /// <summary>
        /// Gets the user details: Harley Hammer.
        /// </summary>
        public static Models.User.UserDetails UserDetailsHarley
            => new Models.User.UserDetails
            {
                Id = TestData.UserHarley.Id,
                Email = TestData.UserHarley.Email,
                Username = TestData.UserHarley.Username,
                Name = TestData.UserHarley.Name,
                Surname = TestData.UserHarley.Surname,
            };

        /// <summary>
        /// Gets the collection of users.
        /// </summary>
        public static User[] Users => new User[]
        {
            TestData.UserTom,
            TestData.UserYo,
            TestData.UserHarley,
        };
    }
}
