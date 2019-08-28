using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Verivox.TariffComparison.Models
{
    /// <summary>
    /// Product details 
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product tariffs defining the the base rate and cents/kWh for consumption, 
        /// including rules for matching consumption. 
        /// </summary>
        public IEnumerable<CalculationModel> Rules { get; set; }

        /// <summary>
        /// Calculate the 
        /// </summary>
        /// <param name="consumptionkWh"></param>
        /// <returns></returns>
        /// <exception cref="InvalidConsumptionRateException">Consumption rate must be a non-negative value, and match</exception>
        public CalculationModel MatchTariff(int consumptionkWh) {

            if (consumptionkWh < 0)
                throw new InvalidConsumptionRateException("Consumption rate does not match allowed calculation rules.  Consumption rate must be a non-negatve number.");

            try
            {                
                // Find matching calculation model for consumption rate
                return Rules.First(rule => rule.MinkWh <= consumptionkWh && rule.MaxkWh > consumptionkWh);
            }
            catch (Exception) {
                throw new InvalidConsumptionRateException("Consumption rate does not match allowed calculation rules.  Consumption rate must be a non-negatve number.");
            }
        }
    }
}
