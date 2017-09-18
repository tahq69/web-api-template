namespace Crip.Samples.Data
{
    using Crip.Samples.Data.Entities;
    using System.Data.Entity;

    /// <summary>
    /// Application database context contract.
    /// </summary>
    public interface IDatabaseContext
    {
        /// <summary>
        /// Gets or sets the users table.
        /// </summary>
        IDbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the roles table.
        /// </summary>
        IDbSet<Role> Roles { get; set; }
    }
}
