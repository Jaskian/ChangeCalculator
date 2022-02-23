using ChangeCalculator.Core.Interfaces;
using ChangeCalculator.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCalculator.Core.Domain.Currency
{
    public class EnglishPoundDenominations : ICurrencyDenominations
    {
        public EnglishPoundDenominations()
        {
            CurrencyDenominations = new List<CurrencyDenomination>()
            {
               new CurrencyDenomination (50, "£50"  ),
               new CurrencyDenomination ( 20, "£20" ),
               new CurrencyDenomination ( 10, "£10" ),
               new CurrencyDenomination (5, "£5" ),
               new CurrencyDenomination (2, "£2"),
               new CurrencyDenomination (1, "£1" ),
               new CurrencyDenomination (0.5M, "50p" ),
               new CurrencyDenomination (0.2M, "20p"),
               new CurrencyDenomination (0.1M, "10p" ),
               new CurrencyDenomination (0.05M, "5p" ),
               new CurrencyDenomination (0.02M, "2p" ),
               new CurrencyDenomination (0.01M, "1p" )
            }.AsReadOnly();
        }
        public IReadOnlyList<CurrencyDenomination> CurrencyDenominations { get; }
    }
}
