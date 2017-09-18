namespace Crip.Samples.Models.Status
{
    /// <summary>
    /// Status details view model.
    /// </summary>
    public class StatusDetails
    {
        /// <summary>
        /// Gets or sets the name of application.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of application.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the database status.
        /// </summary>
        public string Database { get; set; }

        /// <summary>
        /// Gets or sets the version of application.
        /// </summary>
        public string Version { get; set; }
    }
}
