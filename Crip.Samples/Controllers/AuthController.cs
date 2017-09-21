namespace Crip.Samples.Controllers
{
    using Crip.Samples.Models.User;
    using Crip.Samples.Services;
    using Crip.Samples.Validation;
    using System.Threading.Tasks;
    using System.Web.Http;

    /// <summary>
    /// Authorization controller.
    /// </summary>
    /// <seealso cref="Crip.Samples.Controllers.BaseApiController" />
    public class AuthController : BaseApiController
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
            credentials.Validate(new LoginValidator(this.Context));

            var user = await this.UserService.Login(credentials);

            return user;
        }
    }
}
