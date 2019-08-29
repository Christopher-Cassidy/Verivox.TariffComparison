using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Verivox.TariffComparison.Models.Exceptions;
using Verivox.TariffComparison.Tests.Mocks;
using Verivox.TariffComparison.Workflow;

namespace Verivox.TariffComparison.Tests
{
    [TestClass]
    public class ProductConsumptionFilterTests
    {
        [TestMethod]
        public void Filter_ZeroConsumption_ProductsWithDefaultValues()
        {
            // Arrange
            var consumptionkWh = 0;
            var db = new ProductRepositoryMock();
            var filter = GetFilter(consumptionkWh);
            var expectedAnnualCosts = new double[] { 60, 800 };

            // Act
            var result = filter.Filter(db.GetProducts()).ToArray();

            // Assert
            for (int i = 0; i < expectedAnnualCosts.Length - 1; i++)
            {
                Assert.AreEqual(expectedAnnualCosts[i], result[i].AnnualCost);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidConsumptionRateException))]
        public void Filter_NegativeConsumption_ThrowsException()
        {
            // Arrange
            var consumptionkWh = -1;
            var db = new ProductRepositoryMock();
            var filter = GetFilter(consumptionkWh);

            // Act
            var result = filter.Filter(db.GetProducts()).ToArray();

            // Assert
            Assert.Fail("Exception expected");
        }

        [TestMethod]
        public void Filter_ExampleRates_MatchedExampleValues()
        {
            // Arrange
            var db = new ProductRepositoryMock();
            var consumptionRates = new int[] { 3500, 4500, 6000 };
            var expectedAnnualCosts = new double[,] { { 800.0, 830.0 }, { 950.0, 1050.0 }, { 1380.0, 1400.0 } };

            // Act
            var idx = 0;
            foreach (var rate in consumptionRates)
            {
                var filter = GetFilter(rate);
                var result = filter.Filter(db.GetProducts()).ToArray();

                // Assert
                Assert.AreEqual(expectedAnnualCosts[idx, 0], result[0].AnnualCost);

                idx++;
            }
        }

        private ProductConsumptionFilter GetFilter(int consumptionkWh)
        {
            return new ProductConsumptionFilter(consumptionkWh);
        }
    }
}
