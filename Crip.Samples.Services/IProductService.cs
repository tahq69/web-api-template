using Crip.Samples.Models;
using System.Collections.Generic;

namespace Crip.Samples.Services
{
    public interface IProductService
    {
        IEnumerable<Product> All();
        Product Find(int id);
    }
}
