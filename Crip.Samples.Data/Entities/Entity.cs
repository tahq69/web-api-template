namespace Crip.Samples.Data.Entities
{
    using System;

    /// <summary>
    /// Database base entity.
    /// </summary>
    /// <seealso cref="Crip.Samples.Data.Entities.IEntity" />
    public abstract class Entity : IEntity
    {
        /// <summary>
        /// Gets or sets user identifier.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets entity creation date.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets entity last update date.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
