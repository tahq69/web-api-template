namespace Crip.Samples.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Crip.Samples.Models;
    using Crip.Samples.Services;

    /// <summary>
    /// Products controller
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class ProductsController : ApiController
    {
        /// <summary>
        /// Gets or sets the products.
        /// </summary>
        public IProductService Products { get; set; }

        /// <summary>
        /// Gets all products.
        /// </summary>
        /// <returns>Collection of all products.</returns>
        public IEnumerable<Product> GetAllProducts()
        {
            return this.Products.All();
        }

        /// <summary>
        /// Gets the product.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Single product instance.</returns>
        public IHttpActionResult GetProduct(int id)
        {
            var product = this.Products.Find(id);
            if (product == null)
            {
                return this.NotFound();
            }

            return this.Ok(product);
        }
    }
}
