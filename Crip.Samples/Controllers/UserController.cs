namespace Crip.Samples.Controllers
{
    using Crip.Samples.Models.User;
    using Crip.Samples.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http;

    /// <summary>
    /// Products controller
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class UserController : ApiController
    {
        /// <summary>
        /// Gets or sets the user service.
        /// </summary>
        public IUserService UserService { get; set; }

        /// <summary>
        /// Gets collection of all users.
        /// </summary>
        /// <returns>Collection of all users.</returns>
        public async Task<IEnumerable<User>> Index()
        {
            return await this.UserService.All();
        }

        /// <summary>
        /// Gets single user instance.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Single user instance.</returns>
        public async Task<IHttpActionResult> Find(int id)
        {
            var product = await this.UserService.Find(id);
            if (product == null)
            {
                return this.NotFound();
            }

            return this.Ok(product);
        }
    }
}
