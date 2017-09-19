namespace Crip.Samples.Services
{
    using System;

    /// <summary>
    /// Token service contract.
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Create new token with custom time to live.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="tokenTimeToLiveMinutes">The token time to live minutes.</param>
        /// <returns>
        /// User token
        /// </returns>
        string New(string name, long tokenTimeToLiveMinutes = 1440);

        /// <summary>
        /// Get tokens the time to live.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>
        /// Tokens time to live.
        /// </returns>
        TimeSpan TokenTimeToLive(string token);

        /// <summary>
        /// Determines whether the specified token is expired.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>
        /// <c>true</c> if the specified token is expired; otherwise,
        /// <c>false</c>.
        /// </returns>
        bool IsExpired(string token);
    }
}
