namespace Crip.Samples.Services
{
    using Crip.Samples.Models;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Threading.Tasks;

    /// <summary>
    /// Product service EF implementation.
    /// </summary>
    /// <seealso cref="Crip.Samples.Services.Service" />
    /// <seealso cref="Crip.Samples.Services.IProductService" />
    public class ProductService : Service, IProductService
    {
        /// <summary>
        /// Gets all products from database in async manner.
        /// </summary>
        /// <returns>Collection of all products.</returns>
        public async Task<IEnumerable<Product>> AllAsync()
        {
            return await this.Context.Products.ToListAsync();
        }

        /// <summary>
        /// Finds the product by the specified identifier in async manner.
        /// </summary>
        /// <param name="id">The product record identifier.</param>
        /// <returns>Single instance of a product.</returns>
        public async Task<Product> FindAsync(int id)
        {
            return await this.Context.Products.FirstOrDefaultAsync(
                product => product.Id == id);
        }
    }
}
