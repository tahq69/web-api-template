namespace Crip.Samples.Data
{
    using System.Data.Entity;
    using Crip.Samples.Models;

    /// <summary>
    /// Application database context.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        /// <summary>
        /// Gets or sets the products table.
        /// </summary>
        public IDbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the product comments table.
        /// </summary>
        public IDbSet<ProductComment> ProductComments { get; set; }
    }
}
