namespace Crip.Samples.Validation
{
    using Crip.Samples.Exceptions;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Web.Http.Filters;

    /// <summary>
    /// Validation exception attribute.
    /// </summary>
    public class ValidationExceptionAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// Called when [exception] occurs in web API.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is ValidationException)
            {
                var exception = context.Exception as ValidationException;

                var response = new HttpResponseMessage(
                    HttpStatusCode.NotAcceptable);

                response.Content = new StringContent(
                    exception.ToJsonString(),
                    Encoding.UTF8,
                    "application/json");

                context.Response = response;
            }
        }
    }
}
