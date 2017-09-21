namespace Crip.Samples.Controllers
{
    using Crip.Samples.Data;
    using System.Web.Http;

    /// <summary>
    /// Base API controller abstraction.
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public abstract class BaseApiController : ApiController
    {
        /// <summary>
        /// Gets or sets database context.
        /// </summary>
        public IDatabaseContext Context { get; set; }
    }
}
