using Crip.Samples.Models;
using Crip.Samples.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace Crip.Samples.Controllers
{
    public class ProductsController : ApiController
    {
        public IProductService Products { get; set; }

        public IEnumerable<Product> GetAllProducts()
        {
            return this.Products.All();
        }

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
