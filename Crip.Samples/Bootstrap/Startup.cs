using Castle.Windsor;
using Crip.Samples.Validation;
using Microsoft.Owin;
using Owin;
using Owino.Extensions;
using System;
using System.Web.Http;

[assembly: OwinStartup(typeof(Crip.Samples.Bootstrap.Startup))]

namespace Crip.Samples.Bootstrap
{
    /// <summary>
    /// Application startup class
    /// </summary>
    public class Startup : IDisposable
    {
        private readonly IWindsorContainer container = new WindsorContainer();

        /// <summary>
        /// Configurations the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        public void Configuration(IAppBuilder app)
        {
            this.container.Install(new DependencyInstaller());

            var config = new HttpConfiguration();
            var apiDefaults = new
            {
                controller = "Status",
                action = "Index",
                id = RouteParameter.Optional
            };

            config.DependencyResolver = new WindsorHttpDependencyResolver(this.container);
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "WebApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: apiDefaults);

            config.Filters.Add(new ValidationExceptionAttribute());

            app.UseWebApi(config);
            app.RegisterForDisposal(this.container);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing,
        /// releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        /// <c>true</c> to release both managed and unmanaged resources;
        /// <c>false</c> to release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && this.container != null)
            {
                this.container.Dispose();
            }
        }
    }
}
