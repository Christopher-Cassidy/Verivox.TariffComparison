using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Verivox.TariffComparison.Models;
using Verivox.TariffComparison.Tests.Mocks;
using Verivox.TariffComparison.Workflow;

namespace Verivox.TariffComparison.Tests
{
    [TestClass]
    public class ComparisonWorkflowTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_NullProductRepository_ThrowsException()
        {
            // Arrange
            var wf = new ComparisonWorkflow(null);

            // Act

            // Assert
            Assert.Fail("Exception expected");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_NullFilterProperty_ThrowsException()
        {
            // Arrange
            var wf = new ComparisonWorkflow(new ProductRepositoryMock());

            // Act
            wf.Match();

            // Assert
            Assert.Fail("Exception expected");
        }

        [TestMethod]
        public void Match_ValidProducts_MatchedProductTarrifs()
        {
            // Arrange
            var wf = new ComparisonWorkflow(new ProductRepositoryMock());
            wf.ProductFilter = GetMockFilter();
            var expected = ProductTarrifMock.ProductTarrifs;

            // Act
            var results = wf.Match().ToList();

            // Assert
            for (int i = 0; i < results.Count - 1; i++) {
                Assert.AreEqual(expected[i].Name, results[i].Name);
                Assert.AreEqual(expected[i].AnnualCost, results[i].AnnualCost);
            }
        }

        private IProductFilter GetMockFilter()
        {
            var mock = new Mock<IProductFilter>();

            mock.Setup(x => x.Filter(It.IsAny<IEnumerable<Product>>())).Returns(ProductTarrifMock.ProductTarrifs);

            return mock.Object;
        }
    }
}
