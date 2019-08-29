using System;
using System.Collections.Generic;
using System.Linq;
using Verivox.TariffComparison.Models.Exceptions;

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
        /// <example>Basic product tariff</example>
        public string Name { get; set; }

        /// <summary>
        /// Product tariffs defining the the base rate and cents/kWh for consumption, 
        /// including rules for matching consumption. 
        /// </summary>
        public IEnumerable<CalculationModel> Rules { get; set; }        
    }
}
