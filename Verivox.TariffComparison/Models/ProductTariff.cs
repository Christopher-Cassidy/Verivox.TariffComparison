namespace Verivox.TariffComparison.Models
{
    public class ProductTariff {

        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This is the base rate of the tariff exclusive of the consumption rate.  Units: euros/year
        /// </summary>
        public int BaseRate { get; set; }

        /// <summary>
        /// Cost per consumption rate.  Units: euros/kWh.
        /// </summary>
        public int CostPerkWh { get; set; }

        /// <summary>
        /// Consumption rate.  Units: kWh.
        /// </summary>
        public double ConsumptionkWh { get; set; }
    }
}
