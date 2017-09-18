namespace Crip.Samples.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// User entity.
    /// </summary>
    /// <seealso cref="Crip.Samples.Data.Entities.Entity" />
    /// <seealso cref="Crip.Samples.Data.Entities.IEntity" />
    public class User : Entity, IEntity
    {
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets user email.
        /// </summary>
        [MaxLength(254)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets user encrypted password.
        /// </summary>
        [MaxLength(255)]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets user authentication remember token.
        /// </summary>
        [MaxLength(100)]
        public string RememberToken { get; set; }

        /// <summary>
        /// Gets or sets user name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets user surname.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        public virtual ICollection<Role> Roles { get; set; }
            = new HashSet<Role>();
    }
}
