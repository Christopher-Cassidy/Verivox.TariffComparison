namespace Verivox.TariffComparison.ViewModels
{
    /// <summary>
    /// Generic API Error message
    /// </summary>
    public class Error {
        /// <summary>
        /// Error message
        /// </summary>
        /// <example>Consumption rate must be a non-negative value</example>
        public string Message { get; set; }
    }
}
