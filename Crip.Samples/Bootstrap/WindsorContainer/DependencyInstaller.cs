using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Crip.Samples.Services;

namespace Crip.Samples.Bootstrap
{
    public class DependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .Pick().If(t => t.Name.EndsWith("Controller"))
                .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                .LifestylePerWebRequest()
            );

            container.Register(Component.For<IProductService>().ImplementedBy<ProductService>());

            /* container.Register(Component.For<RoleManager<IdentityRole>>()
                .UsingFactoryMethod((kernel, cx) =>
                {
                    var ctx = kernel.Resolve<AuthContext>();
                    return new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(ctx));
                }).LifestylePerWebRequest()
            ); */
        }
    }
}
