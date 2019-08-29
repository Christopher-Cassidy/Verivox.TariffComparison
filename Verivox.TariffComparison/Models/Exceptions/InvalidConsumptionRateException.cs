using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Verivox.TariffComparison.Models.Exceptions
{
    public class InvalidConsumptionRateException : Exception
    {
        /// <summary>
        /// Default exception message
        /// </summary>
        private const string _message = "Consumption rate must be a non-negative value";

        public InvalidConsumptionRateException() : base(_message) { }
        public InvalidConsumptionRateException(string message) : base(message) { }
        public InvalidConsumptionRateException(string message, Exception inner) : base(message, inner) { }
        protected InvalidConsumptionRateException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
