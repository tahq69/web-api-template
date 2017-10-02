namespace Crip.Samples
{
    using System;
    using System.Configuration;

    /// <summary>
    /// Application configuration instance.
    /// </summary>
    /// <seealso cref="Crip.Samples.IConfig" />
    public class Config : IConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Config" /> class.
        /// </summary>
        /// <param name="initialize">
        ///   if set to <c>true</c> initializes values from configuration
        ///   manager.
        /// </param>
        public Config(bool initialize = false)
        {
            if (!initialize)
            {
                return;
            }

            // TODO: initialize configurations from Configuration manager.
        }

        /// <summary>
        /// Get applications the settings string value.
        /// </summary>
        /// <param name="key">Key of the configuration.</param>
        /// <param name="defaultValue">Default value if not configured.</param>
        /// <returns>Configuration string value or default one.</returns>
        private string AppSettings(string key, string defaultValue)
        {
            var value = ConfigurationManager.AppSettings[key];
            if (!string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            return defaultValue;
        }

        /// <summary>
        /// Get applications the settings boolean value.
        /// </summary>
        /// <param name="key">Key of the configuration.</param>
        /// <param name="defaultValue">Default value if not configured.</param>
        /// <returns>Configuration boolean value or default one.</returns>
        private bool AppSettings(string key, bool defaultValue)
        {
            var value = this.AppSettings(key, null);

            if (value != null)
            {
                var ignoreCase = StringComparison.InvariantCultureIgnoreCase;

                return "true".Equals(value, ignoreCase);
            }

            return defaultValue;
        }
    }
}
