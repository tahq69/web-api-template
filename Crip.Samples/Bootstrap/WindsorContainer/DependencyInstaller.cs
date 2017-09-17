namespace Crip.Samples.Bootstrap
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Crip.Samples.Data;
    using Crip.Samples.Services;

    /// <summary>
    /// Library dependency installation configurations.
    /// </summary>
    /// <seealso cref="Castle.MicroKernel.Registration.IWindsorInstaller" />
    public class DependencyInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                .Pick().If(t => t.Name.EndsWith("Controller"))
                .Configure(configurer => configurer.Named(configurer.Implementation.Name))
                .LifestylePerWebRequest());

            container.Register(Component.For<IProductService>().ImplementedBy<ProductService>());
            container.Register(Component.For<IDatabaseContext>().ImplementedBy<DatabaseContext>());

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
