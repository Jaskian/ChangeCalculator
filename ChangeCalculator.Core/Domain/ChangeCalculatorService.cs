using ChangeCalculator.Core.Domain.Response;
using ChangeCalculator.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCalculator.Core.Domain
{
    // yes, this ended up with a silly name because of the namespace
    public class ChangeCalculatorService : IChangeCalculator
    {
        private readonly ICurrencyDenominations _Denominations;

        public ChangeCalculatorService(ICurrencyDenominations currencyDenominations)
        {
            var denominations = new Dictionary<string, decimal>();
            _Denominations = currencyDenominations;
        }

        public ChangeCalculatorResponse Process(decimal currencyAmount, decimal purchasePrice)
        {
            List<Models.ChangeItem> changeItems = new List<Models.ChangeItem>();

            if (currencyAmount == purchasePrice)
            {
                return new ChangeCalculatorResponse(true, changeItems);
            }

            return new ChangeCalculatorResponse(true, changeItems);
        }

    }
}
