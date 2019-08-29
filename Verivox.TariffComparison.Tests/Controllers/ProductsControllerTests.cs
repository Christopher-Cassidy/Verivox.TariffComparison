using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Verivox.TariffComparison.Controllers;
using Verivox.TariffComparison.Tests.Mocks;
using Verivox.TariffComparison.ViewModels;
using Verivox.TariffComparison.Workflow;

namespace Verivox.TariffComparison.Tests.Controllers
{
    [TestClass]
    public class ProductsControllerTests
    {
        [TestMethod]
        public void Get_NullConsumption_ReturnsBadRequest() {
            // Arrange
            var wf = GetWorkflowMock();
            var cntrl = new ProductsController(wf);
            int? consumptionkWh = null;

            // Act
            var response = cntrl.Get(consumptionkWh);
            
            // Assert
            Assert.IsInstanceOfType(response.Result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void Get_NegativeConsumption_ReturnsBadRequest()
        {
            // Arrange
            var wf = GetWorkflowMock();
            var cntrl = new ProductsController(wf);
            int? consumptionkWh = null;

            // Act
            var response = cntrl.Get(consumptionkWh);

            // Assert
            Assert.IsInstanceOfType(response.Result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void Get_PositiveConsumption_ReturnsProductsList()
        {
            // Arrange
            var wf = GetWorkflowMock();
            var cntrl = new ProductsController(wf);
            int? consumptionkWh = 2000;

            // Act
            var response = cntrl.Get(consumptionkWh);
            var result = response.Result as OkObjectResult;
            var products = result.Value as List<ProductTariff>;

            // Assert
            Assert.IsInstanceOfType(response.Result, typeof(OkObjectResult));
            Assert.AreEqual(ProductTarrifMock.ProductTarrifs.Count, products.Count);
        }

        private IComparisonWorkflow GetWorkflowMock() {
            var mock = new Mock<IComparisonWorkflow>();
            
            mock.SetupAllProperties();
            mock.Setup(x => x.Match()).Returns(ProductTarrifMock.ProductTarrifs);

            return mock.Object;
        }
    }
}
