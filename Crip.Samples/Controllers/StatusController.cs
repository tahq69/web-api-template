namespace Crip.Samples.Controllers
{
    using Crip.Samples.Models.Status;
    using Crip.Samples.Services;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Web.Http;

    /// <summary>
    /// Status controller
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class StatusController : ApiController
    {
        /// <summary>
        /// Gets or sets the user service.
        /// </summary>
        public IUserService UserSvc { get; set; }

        /// <summary>
        /// Gets status details instance.
        /// </summary>
        /// <returns>Application status details.</returns>
        [HttpGet]
        [AllowAnonymous]
        [ActionName("Index")]
        public async Task<StatusDetails> GetStatus()
        {
            var (name, description, version) = this.AssemblyDetails();

            var details = new StatusDetails
            {
                Name = name,
                Description = description,
                Version = version.ToString(),
                Database = await this.GetDatabaseStatus(),
            };

            return details;
        }

        /// <summary>
        /// Get databases status details.
        /// </summary>
        /// <returns>Database connection status.</returns>
        [HttpGet]
        [AllowAnonymous]
        [ActionName("Database")]
        public async Task<string> GetDatabaseStatus()
        {
            var status = "OK";

            try
            {
                var users = await this.UserSvc.All();
                users.FirstOrDefault();
            }
            catch (Exception ex)
            {
                status = ex.Message;
            }

            return status;
        }

        private (string name, string description, Version version) AssemblyDetails()
        {
            var assembly = typeof(StatusController).Assembly;
            var version = assembly.GetName().Version;

            var title = assembly
                .GetCustomAttribute<AssemblyTitleAttribute>()?.Title;

            var description = assembly
                .GetCustomAttribute<AssemblyDescriptionAttribute>()?.Description;

            return (title, description, version);
        }
    }
}
