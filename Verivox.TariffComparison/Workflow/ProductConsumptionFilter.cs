using System.Collections.Generic;
using System.Linq;
using Verivox.TariffComparison.Models;
using Verivox.TariffComparison.Models.Exceptions;
using Verivox.TariffComparison.ViewModels;

namespace Verivox.TariffComparison.Workflow
{
    /// <summary>
    /// Product filter based on consumption.  Applies the business rules of each <see cref="Product.Rules"/> to find matching
    /// tariff, and then sort each match <see cref="ProductCalculationModel"/> in ascending order of <see cref="ProductCalculationModel.AnnualCost"/>.
    /// </summary>
    public class ProductConsumptionFilter : IProductFilter
    {
        /// <summary>
        /// Consumption rate to apply against <see cref="ProductCalculationModel"/> rules
        /// </summary>
        private readonly int _consumptionkWh;

        /// <summary>
        /// Filter <see cref="Product"/> tariffs by matching consumption to their <see cref="CalculationModel"/> rules.
        /// </summary>
        /// <param name="consumptionkWh">Annual Energy consumption.  Units: kWh</param>
        public ProductConsumptionFilter(int consumptionkWh)
        {
            if (consumptionkWh < 0)
                throw new InvalidConsumptionRateException();

            _consumptionkWh = consumptionkWh;
        }

        /// <summary>
        /// Filter products and return the matching product and annual cost for the defined annual consumption.
        /// </summary>
        /// <param name="products">Product list to filter</param>
        /// <returns></returns>
        public IEnumerable<ProductTariff> Filter(IEnumerable<Product> products)
        {
            var matchedProducts = Match(products);
            var transformedProducts = Transform(matchedProducts);
            var sortedProducts = Sort(transformedProducts);

            return sortedProducts;
        }

        /// <summary>
        /// Apply the <see cref="ProductCalculationModel"/> rules for each product to the <see cref="_consumptionkWh"/> to find the matching tariff.
        /// </summary>
        /// <param name="products">Products to seach for matching tariffs</param>
        /// <returns>The list of Products with their matching tariff.  If the product does not contain a matching <see cref="CalculationModel"/>, then it is excluded from the returned list or products</returns>
        private IEnumerable<ProductCalculationModel> Match(IEnumerable<Product> products)
        {
            return products
                .Select(product =>
                {
                    var tariff = MatchRule(product);

                    return tariff == null ? null : new ProductCalculationModel
                    {
                        Name = product.Name,
                        Rule = tariff
                    };
                })
                .Where(productTariff => productTariff != null);
        }

        /// <summary>
        /// Tranform the intermediary model into the result model, calculating the Annual Cost
        /// for each product based on the matched tariff.
        /// </summary>
        /// <param name="products">Matched products</param>
        /// <returns>Products with their calculated Annual Cost</returns>
        private IEnumerable<ProductTariff> Transform(IEnumerable<ProductCalculationModel> products)
        {
            return products.Select(product =>
                new ProductTariff
                {
                    Name = product.Name,
                    AnnualCost = CalculateAnnualTariff(product.Rule),
                });
        }

        /// <summary>
        /// Sort the products into the desiered order, by ascending annual cost.
        /// </summary>
        /// <param name="viewModels"></param>
        /// <returns></returns>
        private IEnumerable<ProductTariff> Sort(IEnumerable<ProductTariff> viewModels)
        {
            return viewModels.OrderBy(productTariff => productTariff.AnnualCost);
        }

        /// <summary>
        /// Calculate the annual tariff for the given <see cref="_consumptionkWh"/> rate, and <see cref="CalculationModel"/> rule.
        /// </summary>
        /// <param name="rule">Calculation Model rule</param>
        /// <returns>Annual cost.  Units: euro/year</returns>
        /// <remarks>This method could be extracted out into a seperate class for re-use.</remarks>
        private double CalculateAnnualTariff(CalculationModel rule)
        {
            if (_consumptionkWh < 0)
                throw new InvalidConsumptionRateException();

            return rule.AnnualBaseRate +
                (rule.MonthlyBaseRate * 12) +
                (rule.CostPerkWh * _consumptionkWh) +
                (rule.AdditonalConsumptionCostPerkWh * (_consumptionkWh - rule.MinkWh));
        }

        /// <summary>
        /// Match the Product Calculation Model to the given consumption rate.
        /// </summary>
        /// <param name="product">Product to match</param>
        /// <returns>The matching Calclculation based on its rules and the given consumption rate, or NULL, if no rule matched</returns>
        private CalculationModel MatchRule(Product product)
        {
            // Find matching calculation model for consumption rate
            return product.Rules.FirstOrDefault(rule => 
                rule.MinkWh <= _consumptionkWh && 
                rule.MaxkWh > _consumptionkWh);
        }

        /// <summary>
        /// Intermediary model for a product with matched Calculation Model for the given consumption rate.
        /// </summary>
        private class ProductCalculationModel
        {
            /// <summary>
            /// Product name
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Calculation Model rule
            /// </summary>
            public CalculationModel Rule { get; set; }
        }
    }
}