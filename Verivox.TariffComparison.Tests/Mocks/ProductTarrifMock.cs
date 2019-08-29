using System.Collections.Generic;
using Verivox.TariffComparison.Models;
using Verivox.TariffComparison.ViewModels;

namespace Verivox.TariffComparison.Tests.Mocks
{
    public class ProductTarrifMock
    {
        /// <summary>
        /// Simple static list of products as defined in the task definition.
        /// </summary>
        public static List<ProductTariff> ProductTarrifs { get; } = new List<ProductTariff> {
            new ProductTariff {
                Name = "Packaged tariff",
               AnnualCost = 800.0
            },
            new ProductTariff {
                Name = "Basic electricity tariff",
                AnnualCost = 830.0
            },
        };
    }
}
