namespace Verivox.TariffComparison.Models
{
    /// <summary>
    /// Product tariff calculation model.  Includes the base rate and cost per kWh, and min/max consumption rate rules.
    /// </summary>
    public class CalculationModel
    {
        /// <summary>
        /// This is the base rate of the tariff exclusive of the consumption rate.  Units: euros/year
        /// </summary>
        public double AnnualBaseRate { get; set; }

        /// <summary>
        /// This is the base rate of the tariff exclusive of the consumption rate.  Units: euros/month
        /// </summary>
        public double MonthlyBaseRate { get; set; }

        /// <summary>
        /// Cost per consumption rate.  Units euros/kWh.
        /// </summary>
        public double CostPerkWh { get; set; }

        /// <summary>
        /// Cost per additonal consumption rate above MinkWh.  Units euros/kWh.
        /// </summary>
        public double AdditonalConsumptionCostPerkWh { get; set; }

        /// <summary>
        /// The inclusive minimum value of this consumption rate of this tariff (i.e. consumption >= MinkWh)
        /// </summary>
        public double MinkWh { get; set; }

        /// <summary>
        /// The exclusive maximum value of this consumption rate of this tariff (i.e. consumption &lt; MaxkWh)
        /// </summary>
        public double MaxkWh { get; set; }
    }
}
