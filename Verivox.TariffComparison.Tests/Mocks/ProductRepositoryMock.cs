using System;
using System.Collections.Generic;
using System.Text;
using Verivox.TariffComparison.Data;
using Verivox.TariffComparison.Models;

namespace Verivox.TariffComparison.Tests.Mocks
{
    public class ProductRepositoryMock : IProductRepository
    {
        /// <summary>
        /// Simple static list of products as defined in the task definition.
        /// </summary>
        private static readonly List<Product> Products = new List<Product> {
            new Product {
                Name = "Basic electricity tariff",
                Rules = new List<CalculationModel> {
                    new CalculationModel {
                        AnnualBaseRate = 0,
                        MonthlyBaseRate = 5,
                        AdditonalConsumptionCostPerkWh = 0,
                        CostPerkWh = 0.22,
                        MinkWh = 0,
                        MaxkWh = int.MaxValue
                } } },

            new Product {
                Name = "Packaged tariff",
                Rules = new List<CalculationModel> {
                    new CalculationModel {
                        AnnualBaseRate = 800,
                        MonthlyBaseRate = 0,
                        AdditonalConsumptionCostPerkWh = 0,
                        CostPerkWh = 0,
                        MinkWh = 0,
                        MaxkWh = 4000
                    },
                    new CalculationModel {
                        AnnualBaseRate = 800,
                        MonthlyBaseRate = 0,
                        AdditonalConsumptionCostPerkWh = 0.30,
                        CostPerkWh = 0,
                        MinkWh = 4000,
                        MaxkWh = int.MaxValue
                    } } },
        };

        /// <summary>
        /// Returns the complete list of <see cref="Product"/>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> GetProducts()
        {
            return Products;
        }
    }
}
