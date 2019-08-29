using System.Collections.Generic;
using System.Threading.Tasks;
using Verivox.TariffComparison.Models;
using Verivox.TariffComparison.ViewModels;

namespace Verivox.TariffComparison.Workflow
{
    /// <summary>
    /// Product tariff comparison filter
    /// </summary>
    public interface IProductFilter
    {
        /// <summary>
        /// Search for matching <see cref="Product"/>s using a defined filter
        /// </summary>
        /// <param name="products">Products to search for matched tarrifskWh</param>
        /// <returns>List of Product Tariffs for the given filter</returns>
        IEnumerable<ProductTariff> Filter(IEnumerable<Product> products);
    }
}
