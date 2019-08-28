using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Verivox.TariffComparison.Models
{
    public class InvalidConsumptionRateException : Exception
    {
        public InvalidConsumptionRateException() { }
        public InvalidConsumptionRateException(string message) : base(message) { }
        public InvalidConsumptionRateException(string message, Exception inner) : base(message, inner) { }
        protected InvalidConsumptionRateException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
