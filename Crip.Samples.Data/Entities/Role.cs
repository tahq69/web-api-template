namespace Crip.Samples.Data.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// Role entity.
    /// </summary>
    /// <seealso cref="Crip.Samples.Data.Entities.Entity" />
    /// <seealso cref="Crip.Samples.Data.Entities.IEntity" />
    public class Role : Entity, IEntity
    {
        /// <summary>
        /// Gets or sets role key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public virtual ICollection<User> Users { get; set; }
            = new HashSet<User>();
    }
}
