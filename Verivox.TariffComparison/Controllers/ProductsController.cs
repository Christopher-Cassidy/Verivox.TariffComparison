using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Verivox.TariffComparison.ViewModels;
using Verivox.TariffComparison.Workflow;

namespace Verivox.TariffComparison.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductFilter _comaparisonEngine;

        public ProductsController(IProductFilter comparisonEngine) {
            _comaparisonEngine = comparisonEngine ?? throw new ArgumentNullException(nameof(comparisonEngine));
        }

        // GET api/products/5
        /// <summary>
        /// Gets the ordered list of matching products tariffs for the given
        /// </summary>
        /// <param name="consumptionkWh"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ProductTariffViewModel>> Get([FromQuery]int consumptionkWh)
        {
            return _comaparisonEngine.Match(consumptionkWh).ToList();
        }
    }
}
