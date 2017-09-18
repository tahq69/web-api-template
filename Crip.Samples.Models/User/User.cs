namespace Crip.Samples.Models.User
{
    /// <summary>
    /// User model.
    /// </summary>
    /// <seealso cref="Crip.Samples.Models.IModel" />
    public class User : IModel
    {
        /// <summary>
        /// Gets or sets the identifier of user.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the name of product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the category of product.
        /// </summary>
        public string Surname { get; set; }
    }
}
