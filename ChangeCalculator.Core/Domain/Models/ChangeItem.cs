using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCalculator.Core.Domain.Models
{
    public struct ChangeItem
    {
        public ChangeItem(CurrencyDenomination denomination, int quantity)
        {
            Denomination = denomination;
            Quantity = quantity;
        }

        public CurrencyDenomination Denomination { get; }

        public int Quantity { get; }
    }
}
