namespace Crip.Samples.Bootstrap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Dependencies;
    using Castle.Windsor;

    /// <summary>
    /// Windsor Http Dependency Resolver
    /// </summary>
    /// <seealso cref="System.Web.Http.Dependencies.IDependencyResolver" />
    public class WindsorHttpDependencyResolver : IDependencyResolver
    {
        private readonly IWindsorContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindsorHttpDependencyResolver"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <exception cref="ArgumentNullException">container</exception>
        public WindsorHttpDependencyResolver(IWindsorContainer container)
        {
            this.container = container ?? throw new ArgumentNullException("container");
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <param name="t">The type of t.</param>
        /// <returns>Resolved entity.</returns>
        public object GetService(Type t)
        {
            return this.container.Kernel.HasComponent(t)
             ? this.container.Resolve(t) : null;
        }

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <param name="t">The type of t.</param>
        /// <returns>Resolved entities.</returns>
        public IEnumerable<object> GetServices(Type t)
        {
            return this.container.ResolveAll(t).Cast<object>().ToArray();
        }

        /// <summary>
        /// Starts a resolution scope.
        /// </summary>
        /// <returns>Windsor Dependency Scope.</returns>
        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(this.container);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and
        /// unmanaged resources; <c>false</c> to release only unmanaged
        /// resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
            }

            // free native resources if there are any.
        }
    }
}
