namespace Crip.Samples.Models.User
{
    using System.Collections.Generic;

    /// <summary>
    /// User details model.
    /// </summary>
    /// <seealso cref="Crip.Samples.Models.User.User" />
    /// <seealso cref="Crip.Samples.Models.IModel" />
    public class UserDetails : User, IModel
    {
        /// <summary>
        /// Gets or sets auth token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets user roles.
        /// </summary>
        public ICollection<string> Roles { get; set; }
    }
}
