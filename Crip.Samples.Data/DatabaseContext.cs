namespace Crip.Samples.Data
{
    using System.Data.Entity;
    using Crip.Samples.Models;
    using System.Data.Entity.ModelConfiguration.Conventions;

    /// <summary>
    /// Application database context.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseContext"/> class.
        /// </summary>
        public DatabaseContext()
            : base("ApplicationConnection")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseContext"/> class.
        /// </summary>
        /// <param name="nameOrConnectionString">Either the database name or a
        /// connection string.</param>
        public DatabaseContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        /// <summary>
        /// Gets or sets the products table.
        /// </summary>
        public IDbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the product comments table.
        /// </summary>
        public IDbSet<ProductComment> ProductComments { get; set; }

        /// <summary>
        /// This method is called when the model for a derived context has been
        /// initialized, but before the model has been locked down and used to
        /// initialize the context. The default implementation of this method
        /// does nothing, but it can be overridden in a derived class such that
        /// the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for
        /// the context being created.</param>
        /// <remarks>
        /// Typically, this method is called only once when the first instance
        /// of a derived context is created. The model for that context is then
        /// cached and is for all further instances of the context in the app
        /// domain.  This caching can be disabled by setting the ModelCaching
        /// property on the given ModelBuidler, but note that this can seriously
        /// degrade performance. More control over caching is provided through
        /// use of the DbModelBuilder and DbContextFactory classes directly.
        /// </remarks>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
