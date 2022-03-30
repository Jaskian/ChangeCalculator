using ChangeCalculator.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChangeCalculator.Core.Domain.Response
{
    public class ChangeCalculatorRequest
    {
        [Required]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid currency amount")]
        public decimal CurrencyAmount { get; set; }

        [Required]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid purchase price")]
        public decimal PurchasePrice { get; set; }
    }

}
