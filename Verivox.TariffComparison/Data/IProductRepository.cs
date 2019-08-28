using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Verivox.TariffComparison.Models;

namespace Verivox.TariffComparison.Data
{
    /// <summary>
    /// Product Repository interface.  Implementations of this interface could be a Database Data Context, Cache, External web service, or simple in-memory data store.
    /// </summary>
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
    }
}
