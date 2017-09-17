namespace Crip.Samples.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
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
        /// Gets collection of all products.
        /// </summary>
        /// <returns>Collection of all products.</returns>
        public async Task<IEnumerable<Product>> Index()
        {
            return await this.Products.AllAsync();
        }

        /// <summary>
        /// Gets single product instance.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Single product instance.</returns>
        public async Task<IHttpActionResult> Find(int id)
        {
            var product = await this.Products.FindAsync(id);
            if (product == null)
            {
                return this.NotFound();
            }

            return this.Ok(product);
        }
    }
}
