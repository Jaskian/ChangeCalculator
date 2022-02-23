using ChangeCalculator.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCalculator.Core.Domain.Response
{
    public class ChangeCalculatorResponse
    {
        public ChangeCalculatorResponse(bool success, IEnumerable<ChangeItem> changeItems)
        {
            Success = success;
            ChangeItems = changeItems;
        }

        public bool Success { get; set; }

        public string Error { get; set; }

        public IEnumerable<ChangeItem> ChangeItems { get; set; }
    }

}
