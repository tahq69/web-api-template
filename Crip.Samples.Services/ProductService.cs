using Crip.Samples.Models;
using System.Collections.Generic;
using System.Linq;

namespace Crip.Samples.Services
{
    public class ProductService : IProductService
    {
        protected Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        public IEnumerable<Product> All()
        {
            return this.products;
        }

        public Product Find(int id)
        {
            return products.FirstOrDefault((p) => p.Id == id);
        }
    }
}
