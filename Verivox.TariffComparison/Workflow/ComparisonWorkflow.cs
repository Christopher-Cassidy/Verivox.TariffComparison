using System;
using System.Collections.Generic;
using Verivox.TariffComparison.Data;
using Verivox.TariffComparison.ViewModels;

namespace Verivox.TariffComparison.Workflow
{
    /// <summary>
    /// Product Comparison workflow implementation.  The workflow requires a <see cref="IProductFilter"/> to match products. 
    /// </summary>
    public class ComparisonWorkflow : IComparisonWorkflow
    {
        /// <summary>
        /// Products repository
        /// </summary>
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
        /// <remarks>The product repository could be removed from this constructor, 
        /// and a predefined list of products passed in the Match method instead.</remarks>
        public ComparisonWorkflow(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        /// <summary>
        /// Match products using the defined <see cref="IProductFilter"/>, and return the caulculated <see cref="ProductTariff"/>
        /// </summary>
        /// <returns>The matched list of <see cref="ProductTariff"/>s</returns>
        public IEnumerable<ProductTariff> Match()
        {
            if (ProductFilter == null)
                throw new ArgumentNullException(nameof(ProductFilter));

            var products = _productRepository.GetProducts();

            return ProductFilter.Filter(products);
        }
    }
}
