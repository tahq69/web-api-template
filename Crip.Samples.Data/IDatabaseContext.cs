namespace Crip.Samples.Data
{
    using Crip.Samples.Data.Entities;
    using System.Data.Entity;
    using System.Threading;
    using System.Threading.Tasks;

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

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of state entries written to the underlying database.
        /// This can include state entries for entities and/or relationships.
        /// Relationship state entries are created for many-to-many
        /// relationships and relationships where there is no foreign key
        /// property included in the entity class (often referred to as
        /// independent associations).
        /// </returns>
        int SaveChanges();

        /// <summary>
        /// Asynchronously saves all changes made in this context to the
        /// underlying database.
        /// </summary>
        /// <param name="cancellationToken">
        /// A System.Threading.CancellationToken to observe while waiting for
        /// the task to complete.
        /// </param>
        /// <returns>
        /// A task that represents the asynchronous save operation. The task
        /// result contains the number of state entries written to the
        /// underlying database. This can include state entries for entities
        /// and/or relationships. Relationship state entries are created for
        /// many-to-many relationships and relationships where there is no
        /// foreign key property included in the entity class (often referred
        /// to as independent associations).
        /// </returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Asynchronously saves all changes made in this context to the
        /// underlying database.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous save operation. The task
        /// result contains the number of state entries written to the
        /// underlying database. This can include state entries for entities
        /// and/or relationships. Relationship state entries are created for
        /// many-to-many relationships and relationships where there is no
        /// foreign key property included in the entity class (often referred
        /// to as independent associations).
        /// </returns>
        Task<int> SaveChangesAsync();
    }
}
