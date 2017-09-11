using System.Web.Http;
using Castle.Windsor;
using Microsoft.Owin;
using Owin;
using Owino.Extensions;

[assembly: OwinStartup(typeof(Crip.Samples.Bootstrap.Startup))]

namespace Crip.Samples.Bootstrap
{
    /// <summary>
    /// Application startup class
    /// </summary>
    public class Startup
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

            config.DependencyResolver = new WindsorHttpDependencyResolver(this.container);
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "WebApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "Status", action = "Get", id = RouteParameter.Optional });

            app.UseWebApi(config);
            app.RegisterForDisposal(this.container);
        }
    }
}
