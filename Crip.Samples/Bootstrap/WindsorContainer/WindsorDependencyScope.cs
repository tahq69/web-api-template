namespace Crip.Samples.Bootstrap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Dependencies;
    using Castle.MicroKernel.Lifestyle;
    using Castle.Windsor;

    /// <summary>
    /// Windsor Dependency Scope
    /// </summary>
    /// <seealso cref="System.Web.Http.Dependencies.IDependencyScope" />
    public class WindsorDependencyScope : IDependencyScope
    {
        private readonly IWindsorContainer container;
        private readonly IDisposable scope;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindsorDependencyScope"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <exception cref="System.ArgumentNullException">container</exception>
        public WindsorDependencyScope(IWindsorContainer container)
        {
            this.container = container ?? throw new ArgumentNullException("container");
            this.scope = container.BeginScope();
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <param name="t">The type of t.</param>
        /// <returns>Resolved component instance.</returns>
        public object GetService(Type t)
        {
            return this.container.Kernel.HasComponent(t)
                ? this.container.Resolve(t) : null;
        }

        /// <summary>
        /// Gets the services.
        /// </summary>
        /// <param name="t">The t.</param>
        /// <returns>Resolved components instances.</returns>
        public IEnumerable<object> GetServices(Type t)
        {
            return this.container.ResolveAll(t).Cast<object>().ToArray();
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
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                this.scope.Dispose();
            }

            // free native resources if there are any.
        }
    }
}
