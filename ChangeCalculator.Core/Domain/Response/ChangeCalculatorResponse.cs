using ChangeCalculator.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChangeCalculator.Core.Domain.Response
{
    public class ChangeCalculatorResponse
    {
        public ChangeCalculatorResponse(bool success, IEnumerable<ChangeItem> changeItems, ErrorTypes? errorType = default)
        {
            Success = success;
            ChangeItems = changeItems;
            Error = errorType;
        }

        public bool Success { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ErrorTypes? Error { get; set; }

        public IEnumerable<ChangeItem> ChangeItems { get; set; }

        public enum ErrorTypes
        {

            [Description("The purchase price exceeds the currency provided")]
            PurchaseExceedsCurrency = 0,
            [Description("Purchase price not provided")]
            PurchasePriceNotProvided = 1,
            [Description("Invalid")]
            InvalidCurrencyAmount = 2

        }
    }

}
