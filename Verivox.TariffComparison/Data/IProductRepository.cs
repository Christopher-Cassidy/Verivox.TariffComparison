using System.Collections.Generic;
using Verivox.TariffComparison.Models;

namespace Verivox.TariffComparison.Data
{
    /// <summary>
    /// Product Repository interface.
    /// </summary>
    /// <remarks>
    /// Implementations of this interface could be a Database Data Context, Cache, External web service, or simple in-memory data store.
    /// </remarks>
    public interface IProductRepository
    {
        /// <summary>
        /// Returns the complete list of <see cref="Product"/>s
        /// </summary>
        /// <returns></returns>
        IEnumerable<Product> GetProducts();
    }
}
