using System;
using System.Collections.Generic;
using System.Linq;
using Verivox.TariffComparison.Data;
using Verivox.TariffComparison.Models;
using Verivox.TariffComparison.ViewModels;

namespace Verivox.TariffComparison.Workflow
{
    /// <summary>
    /// Product filter based on consumption.  Applies the business rules of each <see cref="Product.Rules"/> to find matching 
    /// tariff, and then sort each match <see cref="ProductTariff"/> in ascending order of <see cref="ProductTariff.AnnualCost"/>.
    /// </summary>
    public class ProductConsumptionFilter : IProductFilter
    {
        private readonly IProductRepository _productsRepository;

        public ProductConsumptionFilter(IProductRepository productsRepository)
        {
            _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
        }

        public IEnumerable<ProductTariffViewModel> Match(int consumptionkWh)
        {
            var products = _productsRepository.GetProducts();

            return products
                .Where(product => product.Rules.Any(rule => rule.MinkWh < consumptionkWh && rule.MaxkWh >= consumptionkWh))
                .Select(product =>
                {
                    var annualTariff = product.MatchTariff(consumptionkWh).CalculateAnnualTariff(consumptionkWh);
                    return new ProductTariffViewModel { Name = product.Name, AnnualCost = annualTariff };
                })
                .OrderBy(productTariff => productTariff.AnnualCost);
        }
                
        //private IEnumerable<ProductTariff> Filter(IEnumerable<Product> products, int consumptionkWh)
        //{
        //    return products
        //        .Select(product =>
        //        {
        //            var tariff = product.Rules.FirstOrDefault(rule => rule.MinkWh < consumptionkWh && rule.MaxkWh >= consumptionkWh);

        //            return tariff == null ? null : new ProductTariff
        //            {
        //                Name = product.Name,
        //                ConsumptionkWh = consumptionkWh,
        //                BaseRate = tariff.BaseRate,
        //                CostPerkWh = tariff.CostPerkWh
        //            };
        //        })
        //        .Where(productTariff => productTariff != null);
        //}

        //private IEnumerable<ProductTariffViewModel> Transform(IEnumerable<ProductTariff> products)
        //{
        //    return products.Select(product =>
        //        new ProductTariffViewModel
        //        {
        //            Name = product.Name,
        //            AnnualCost = product.BaseRate + product.CostPerkWh * product.ConsumptionkWh
        //        });
        //}

        //private IEnumerable<ProductTariffViewModel> Sort(IEnumerable<ProductTariffViewModel> viewModels)
        //{
        //    return viewModels.OrderBy(productTariff => productTariff.AnnualCost);
        //}
    }
}
