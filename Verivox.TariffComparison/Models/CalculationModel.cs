using System;

namespace Verivox.TariffComparison.Models
{
    /// <summary>
    /// Product tariff calculation model.  Includes the base rate and cost per kWh, and min/max consumption rate rules.
    /// </summary>
    public class CalculationModel {
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

        /// <summary>
        /// Calculate the 
        /// </summary>
        /// <param name="consumptionkWh"></param>
        /// <returns></returns>
        /// <exception cref="InvalidConsumptionRateException">Consumption rate must be a non-negative value, and match</exception>
        public double CalculateAnnualTariff(int consumptionkWh)
        {
            if (consumptionkWh < 0)
                throw new InvalidConsumptionRateException("Consumption rate does not match allowed calculation rules.  Consumption rate must be a non-negatve number.");

            try
            {
                return AnnualBaseRate +
                    (MonthlyBaseRate * 12) +
                    (CostPerkWh * consumptionkWh) +
                    (AdditonalConsumptionCostPerkWh * (consumptionkWh - MinkWh));
            }
            catch (Exception)
            {
                throw new InvalidConsumptionRateException("Consumption rate does not match allowed calculation rules.  Consumption rate must be a non-negatve number.");
            }
        }
    }
}
