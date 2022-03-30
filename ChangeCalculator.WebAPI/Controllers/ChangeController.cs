using ChangeCalculator.Core.Domain.Response;
using ChangeCalculator.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        [HttpGet("{CurrencyAmount}/{PurchasePrice}")]
        [ProducesResponseType(typeof(ChangeCalculatorResponse), 200)]
        [ProducesResponseType(typeof(ChangeCalculatorResponse), 400)]
        public IActionResult Get([FromRoute]ChangeCalculatorRequest request)
        {
            ChangeCalculatorResponse result = ChangeCalculator.Process(request.CurrencyAmount, request.PurchasePrice);

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
