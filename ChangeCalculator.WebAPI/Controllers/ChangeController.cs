using ChangeCalculator.Core.Domain.Response;
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
        [ProducesResponseType(typeof(ChangeCalculatorResponse), 200)]
        [ProducesResponseType(typeof(ChangeCalculatorResponse), 400)]
        public IActionResult Get(decimal currencyAmount, decimal purchasePrice)
        {
            ChangeCalculatorResponse result = ChangeCalculator.Process(currencyAmount, purchasePrice);

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
