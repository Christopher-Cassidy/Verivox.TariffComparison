using System;
using System.Collections.Generic;
using Verivox.TariffComparison.Data;
using Verivox.TariffComparison.ViewModels;

namespace Verivox.TariffComparison.Workflow
{
    public class ComparisonWorkflow: IComparisonWorkflow
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Product filter to use to match products
        /// </summary>
        /// <remarks>Public property to allow for property injection</remarks>
        public IProductFilter ProductFilter { get; set; }

        /// <summary>
        /// Comparison workflow for matching products against the provided filter.
        /// </summary>
        /// <param name="productRepository">Product data source</param>
        public ComparisonWorkflow(IProductRepository productRepository) {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        /// <summary>
        /// Match products using the defined <see cref="IProductFilter"/>, and return the caulculated <see cref="ProductTariff"/>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductTariff> Match() {
            if (ProductFilter == null)
                throw new ArgumentNullException(nameof(ProductFilter));

            var products = _productRepository.GetProducts();

            return ProductFilter.Filter(products);
        }
    }
}
