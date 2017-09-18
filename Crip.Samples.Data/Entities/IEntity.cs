namespace Crip.Samples.Data.Entities
{
    using System;

    /// <summary>
    /// Database entity model contract.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets entity identifier.
        /// </summary>
        long Id { get; set; }

        /// <summary>
        /// Gets or sets entity creation date.
        /// </summary>
        DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets entity last update date.
        /// </summary>
        DateTime UpdatedAt { get; set; }
    }
}
