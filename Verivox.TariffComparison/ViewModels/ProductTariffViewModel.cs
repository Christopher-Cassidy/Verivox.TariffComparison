namespace Verivox.TariffComparison.ViewModels
{
    /// <summary>
    /// Product Tariff view model.  The product tariff includes the <see cref="Name"/> and <see cref="AnnualCost"/> best matched for a given consumption.
    /// </summary>
    public class ProductTariffViewModel {

        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Annual cost of product.  Units: euro/year
        /// </summary>
        public double AnnualCost { get; set; }
    }
}
