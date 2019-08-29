namespace Verivox.TariffComparison.ViewModels
{
    /// <summary>
    /// Product Tariff view model.  The product tariff includes the <see cref="Name"/> and <see cref="AnnualCost"/> best matched for a given consumption.
    /// </summary>
    public class ProductTariff {

        /// <summary>
        /// Product Name
        /// </summary>
        /// <example>Basic product tariff</example>
        public string Name { get; set; }

        /// <summary>
        /// Annual cost of product.  Units: euro/year
        /// </summary>
        /// <example>600.00</example>
        public double AnnualCost { get; set; }
    }
}
