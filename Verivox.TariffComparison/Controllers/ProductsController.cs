using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Verivox.TariffComparison.Models.Exceptions;
using Verivox.TariffComparison.ViewModels;
using Verivox.TariffComparison.Workflow;

namespace Verivox.TariffComparison.Controllers
{
    /// <summary>
    /// Products API.  This api provides a method for listing products with annual costs for a given consumption kWh.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]    
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Engine for comparig product tariffs
        /// </summary>
        private readonly IComparisonWorkflow _comparisonWorkflow;

        /// <summary>
        /// Products API
        /// </summary>
        /// <param name="comparisonWorkflow">Product Comparison Workflow used to filter products</param>
        public ProductsController(IComparisonWorkflow comparisonWorkflow) {
            _comparisonWorkflow = comparisonWorkflow ?? throw new ArgumentNullException(nameof(comparisonWorkflow));
        }

        // GET api/products/5
        /// <summary>
        /// Gets the ordered list of matching products tariffs for the given consumption rate.
        /// </summary>
        /// <param name="consumptionkWh">Annual consumption. This must be a non-negative value.  Units: kWh</param>
        /// <returns>Ordered list of products with annual cost for the given consumption</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        public ActionResult<List<ProductTariff>> Get([FromQuery]int? consumptionkWh)
        {
            try {
                if (!consumptionkWh.HasValue)
                    throw new InvalidConsumptionRateException();

                _comparisonWorkflow.ProductFilter = new ProductConsumptionFilter(consumptionkWh.Value);

                return Ok(_comparisonWorkflow.Match().ToList());
            }
            catch (InvalidConsumptionRateException ex) {
                return BadRequest(new Error { Message = ex.Message });
            }
            catch (Exception) {
                return StatusCode(500, new Error { Message = "Internal server error" });
            }
        }
    }
}
