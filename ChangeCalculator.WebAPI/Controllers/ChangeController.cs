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
        [ProducesResponseType(typeof(Core.Domain.ChangeCalculatorResult), 200)]
        public IActionResult Get(decimal currencyAmount, decimal purchasePrice)
        {
            Core.Domain.ChangeCalculatorResult result = ChangeCalculator.Process(currencyAmount, purchasePrice);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
