namespace Crip.Samples.Services
{
    using System;

    /// <summary>
    /// Token service.
    /// </summary>
    /// <seealso cref="Crip.Samples.Services.ITokenService" />
    public class TokenService : ITokenService
    {
        /// <summary>
        /// Determines whether the specified token is expired.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>
        /// <c>true</c> if the specified token is expired; otherwise,
        /// <c>false</c>.
        /// </returns>
        public bool IsExpired(string token)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create new token.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="tokenTimeToLiveMinutes">The token time to live minutes.</param>
        /// <returns>
        /// User token
        /// </returns>
        public string New(string name, long tokenTimeToLiveMinutes = 1440)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get tokens the time to live.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>
        /// Tokens time to live.
        /// </returns>
        public TimeSpan TokenTimeToLive(string token)
        {
            throw new NotImplementedException();
        }
    }
}
