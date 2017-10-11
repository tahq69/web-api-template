namespace Crip.Samples.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;
    using System.Threading.Tasks;
    using Crip.Samples.Data.Entities;

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
        /// Gets the database transaction.
        /// </summary>
        public DbContextTransaction Transaction { get; private set; }

        /// <summary>
        /// Gets or sets the users table.
        /// </summary>
        public IDbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the roles table.
        /// </summary>
        public IDbSet<Role> Roles { get; set; }

        /// <summary>
        /// Begins database transaction.
        /// </summary>
        public void BeginTransaction()
        {
            this.Transaction = this.Database.BeginTransaction();
        }

        /// <summary>
        /// Commits database transaction.
        /// </summary>
        public void Commit()
        {
            this.Transaction.Commit();
        }

        /// <summary>
        /// Rollbacks database transaction.
        /// </summary>
        public void Rollback()
        {
            this.Transaction.Rollback();
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of state entries written to the underlying database.
        /// This can include state entries for entities and/or relationships.
        /// Relationship state entries are created for many-to-many
        /// relationships and relationships where there is no foreign key
        /// property included in the entity class (often referred to as
        /// independent associations).
        /// </returns>
        public override int SaveChanges()
        {
            this.ModifyAuditables();
            return base.SaveChanges();
        }

        /// <summary>
        /// Asynchronously saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous save operation.
        /// The task result contains the number of state entries written to the underlying database. This can include
        /// state entries for entities and/or relationships. Relationship state entries are created for
        /// many-to-many relationships and relationships where there is no foreign key property
        /// included in the entity class (often referred to as independent associations).
        /// </returns>
        /// <remarks>
        /// Multiple active operations on the same context instance are not supported.  Use 'await' to ensure
        /// that any asynchronous operations have completed before calling another method on this context.
        /// </remarks>
        public override Task<int> SaveChangesAsync()
        {
            this.ModifyAuditables();
            return base.SaveChangesAsync();
        }

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

        /// <summary>
        /// Modifies the auditable entities.
        /// </summary>
        private void ModifyAuditables()
        {
            var now = DateTime.UtcNow;

            this.ChangeTracker.Entries<IEntity>()
                .Where(p => p.State == EntityState.Added)
                .Select(p => p.Entity).ToList()
                .ForEach(x => x.CreatedAt = x.UpdatedAt = now);

            this.ChangeTracker.Entries<IEntity>()
                .Where(p => p.State == EntityState.Modified)
                .Select(p => p.Entity).ToList()
                .ForEach(x => x.UpdatedAt = now);
        }
    }
}
