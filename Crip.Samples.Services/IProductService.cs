namespace Crip.Samples.Services
{
    using System.Collections.Generic;
    using Crip.Samples.Models;
    using System.Threading.Tasks;

    /// <summary>
    /// Product service contract.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets all products from database in async manner.
        /// </summary>
        /// <returns>Collection of all products.</returns>
        Task<IEnumerable<Product>> AllAsync();

        /// <summary>
        /// Finds the product by the specified identifier in async manner.
        /// </summary>
        /// <param name="id">The product record identifier.</param>
        /// <returns>Single instance of a product.</returns>
        Task<Product> FindAsync(int id);
    }
}
