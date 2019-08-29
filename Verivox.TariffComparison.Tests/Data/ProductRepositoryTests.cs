using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Verivox.TariffComparison.Data;

namespace Verivox.TariffComparison.Tests.Data
{
    [TestClass]
    public class ProductRepositoryTests
    {
        [TestMethod]
        public void Ctor_ReturnsInstance()
        {
            // Arrange
            var db = new ProductRepository();

            // Act

            // Assert
            Assert.IsNotNull(db);
        }

        [TestMethod]
        public void GetProducts_ReturnsProductsList()
        {
            // Arrange
            var db = new ProductRepository();

            // Act
            var results = db.GetProducts();

            // Assert
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Count() > 0);
        }
    }
}