namespace Crip.Samples.Data
{
    using Crip.Samples.Models;
    using System.Data.Entity;

    /// <summary>
    /// Application database context contract.
    /// </summary>
    public interface IDatabaseContext
    {
        /// <summary>
        /// Gets or sets the products table.
        /// </summary>
        IDbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the product comments table.
        /// </summary>
        IDbSet<ProductComment> ProductComments { get; set; }
    }
}
