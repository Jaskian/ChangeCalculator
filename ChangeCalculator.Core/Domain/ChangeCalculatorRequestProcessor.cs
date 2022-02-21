using ChangeCalculator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCalculator.Core.Domain
{
    public class ChangeCalculatorRequestProcessor : IChangeCalculator
    {
        public ChangeCalculatorResult Process(decimal currencyAmount, decimal purchasePrice)
        {
            return new ChangeCalculatorResult()
            {
                Success = true
            };
        }
    }
}
