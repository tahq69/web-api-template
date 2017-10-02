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

            container.Register(Component.For<IConfig>()
                .UsingFactoryMethod((kernel, cx) => new Config(true))
                .LifestyleSingleton());

            container.Register(Component.For<IDatabaseContext>().ImplementedBy<DatabaseContext>());
            container.Register(Component.For<INotificationService>().ImplementedBy<NotificationService>());
            container.Register(Component.For<ISecurityService>().ImplementedBy<SecurityService>());
            container.Register(Component.For<ITokenService>().ImplementedBy<TokenService>());
            container.Register(Component.For<IUserService>().ImplementedBy<UserService>());
        }
    }
}
