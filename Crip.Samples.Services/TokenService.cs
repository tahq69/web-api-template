namespace Crip.Samples.Services
{
    using Newtonsoft.Json;
    using System;
    using System.Text;

    /// <summary>
    /// Token service.
    /// </summary>
    /// <seealso cref="Crip.Samples.Services.ITokenService" />
    public class TokenService : ITokenService
    {
        private readonly string salt;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenService"/> class.
        /// </summary>
        /// <param name="salt">The salt.</param>
        public TokenService(string salt = "KAYNGSOGYSVOJNSDKFH")
        {
            this.salt = salt;
        }

        /// <summary>
        /// Gets user guid from the specified token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>
        /// User guid.
        /// </returns>
        public string GetGuid(string token)
        {
            var data = this.GetData(token);

            return data.Guid;
        }

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
            var data = this.GetData(token);

            return data.ExpiresAt < DateTime.UtcNow;
        }

        /// <summary>
        /// Create new token.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="tokenTimeToLiveMinutes">The token time to live minutes.</param>
        /// <returns>
        /// User token and guid.
        /// </returns>
        public (string token, string userGuid) New(
            string name, long tokenTimeToLiveMinutes = 1440)
        {
            var data = new TokenData
            {
                ExpiresAt = DateTime.UtcNow.AddMinutes(tokenTimeToLiveMinutes),
                Username = name,
                Guid = Guid.NewGuid().ToString(),
            };

            var tokenValue = JsonConvert.SerializeObject(data);
            var crypted = StringCipher.Encrypt(tokenValue, this.salt);

            var token = Convert.ToBase64String(Encoding.UTF8.GetBytes(crypted));

            return (token, data.Guid);
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
            var data = this.GetData(token);

            return new TimeSpan(data.ExpiresAt.Ticks - DateTime.UtcNow.Ticks);
        }

        private TokenData GetData(string token)
        {
            var bytes = Convert.FromBase64String(token);
            var crypted = UTF8Encoding.UTF8.GetString(bytes);
            var decrypted = StringCipher.Decrypt(crypted, this.salt);

            var data = JsonConvert.DeserializeObject<TokenData>(decrypted);

            return data;
        }
    }
}
