using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCalculator.Core.Domain.Models
{
    public struct CurrencyDenomination
    {
        public CurrencyDenomination(decimal value, string description)
        {
            Value = value;
            Description = description;
        }

        public decimal Value { get; }

        public string Description { get; }
      
    }
}
