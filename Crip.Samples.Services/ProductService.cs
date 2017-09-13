namespace Crip.Samples.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Crip.Samples.Models;

    /// <summary>
    /// Product service EF implementation.
    /// </summary>
    /// <seealso cref="Crip.Samples.Services.IProductService" />
    public class ProductService : IProductService
    {
        private Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        /// <summary>
        /// Gets all products from database.
        /// </summary>
        /// <returns>Collection of all products.</returns>
        public IEnumerable<Product> All()
        {
            return this.products;
        }

        /// <summary>
        /// Finds the product by the specified identifier.
        /// </summary>
        /// <param name="id">The product record identifier.</param>
        /// <returns>Single instance of a product.</returns>
        public Product Find(int id)
        {
            return this.products.FirstOrDefault((p) => p.Id == id);
        }
    }
}
