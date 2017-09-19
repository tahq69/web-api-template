namespace Crip.Samples.Services
{
    using System;

    /// <summary>
    /// Token data model.
    /// </summary>
    internal class TokenData
    {
        /// <summary>
        /// Gets or sets token expiration date.
        /// </summary>
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        public string Guid { get; set; }
    }
}
