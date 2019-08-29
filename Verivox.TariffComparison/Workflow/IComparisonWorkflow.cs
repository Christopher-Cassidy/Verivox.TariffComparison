using System.Collections.Generic;
using Verivox.TariffComparison.ViewModels;

namespace Verivox.TariffComparison.Workflow
{
    /// <summary>
    /// Product Comparison interface for matching products
    /// </summary>
    public interface IComparisonWorkflow {
        /// <summary>
        /// Comparison filter
        /// </summary>
        IProductFilter ProductFilter { get; set; }

        /// <summary>
        /// Match products against a defined filter, and return the calculated product tariff
        /// </summary>
        /// <returns>List of matched products and their annual cost</returns>
        IEnumerable<ProductTariff> Match();
    }
}
