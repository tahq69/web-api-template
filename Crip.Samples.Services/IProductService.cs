namespace Crip.Samples.Services
{
    using System.Collections.Generic;
    using Crip.Samples.Models;

    /// <summary>
    /// Product service contract.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets all products from database.
        /// </summary>
        /// <returns>Collection of all products.</returns>
        IEnumerable<Product> All();

        /// <summary>
        /// Finds the product by the specified identifier.
        /// </summary>
        /// <param name="id">The product record identifier.</param>
        /// <returns>Single instance of a product.</returns>
        Product Find(int id);
    }
}
