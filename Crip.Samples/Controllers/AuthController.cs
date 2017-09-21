namespace Crip.Samples.Controllers
{
    using Crip.Samples.Models.User;
    using Crip.Samples.Services;
    using System.Threading.Tasks;
    using System.Web.Http;

    /// <summary>
    /// Authorization controller.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class AuthController : ApiController
    {
        /// <summary>
        /// Gets or sets the user service.
        /// </summary>
        public IUserService UserService { get; set; }

        /// <summary>
        /// Authorize user in system and provide him with token.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <returns>
        /// Authorized user details.
        /// </returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<UserDetails> Login(Credentials credentials)
        {
            // TODO: validate data before call service.
            var user = await this.UserService.Login(credentials);

            return user;
        }
    }
}
