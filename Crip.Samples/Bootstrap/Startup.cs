using Castle.Windsor;
using Microsoft.Owin;
using Owin;
using Owino.Extensions;
using System.Web.Http;

[assembly: OwinStartup(typeof(Crip.Samples.Bootstrap.Startup))]

namespace Crip.Samples.Bootstrap
{
    public class Startup
    {
        private readonly IWindsorContainer container = new WindsorContainer();

        public void Configuration(IAppBuilder app)
        {
            this.container.Install(new DependencyInstaller());

            var config = new HttpConfiguration();

            config.DependencyResolver = new WindsorHttpDependencyResolver(container);
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "WebApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "Status", action = "Get", id = RouteParameter.Optional }
            );

            app.UseWebApi(config);
            app.RegisterForDisposal(this.container);
        }
    }
}
