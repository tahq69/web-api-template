namespace Crip.Samples.Validation
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Filters;

    /// <summary>
    /// Unauthorized access attribute
    /// </summary>
    /// <seealso cref="System.Web.Http.Filters.ExceptionFilterAttribute" />
    public class UnauthorizedAccessAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Called when [exception] occurs in web API.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is UnauthorizedAccessException)
            {
                context.Response = new HttpResponseMessage(
                    HttpStatusCode.Unauthorized);
            }
        }
    }
}
