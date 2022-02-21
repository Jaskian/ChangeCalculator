using ChangeCalculator.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChangeCalculator.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangeController : ControllerBase
    {
        IChangeCalculator ChangeCalculator { get; set; }

        public ChangeController(IChangeCalculator changeCalculator)
        {
            ChangeCalculator = changeCalculator;
        }

        // GET api/<ChangeController>/50/10
        [HttpGet("{currencyAmount:decimal}/{purchasePrice:decimal}")]
        public IActionResult Get(decimal currencyAmount, decimal purchasePrice)
        {
            var result = ChangeCalculator.Process(currencyAmount, purchasePrice);

            return Ok(result);
        }
    }
}
