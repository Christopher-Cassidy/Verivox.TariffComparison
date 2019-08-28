using System.Collections.Generic;
using System.Threading.Tasks;
using Verivox.TariffComparison.ViewModels;

namespace Verivox.TariffComparison.Workflow
{
    /// <summary>
    /// Product tariff comparison filter
    /// </summary>
    public interface IProductFilter
    {
        /// <summary>
        /// Search for matching product tariffs for the given <paramref name="consumptionKwH"/>.
        /// </summary>
        /// <param name="consumptionKwH">Consumption basis in kWh</param>
        /// <returns>List of Product Tariffs for the given <paramref name="consumptionkWh"/></returns>
        IEnumerable<ProductTariffViewModel> Match(int consumptionkWh);
    }
}
