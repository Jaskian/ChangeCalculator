using ChangeCalculator.Core.Domain.Models;
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

            if (currencyAmount < purchasePrice)
            {
                return new ChangeCalculatorResponse(false, changeItems, ChangeCalculatorResponse.ErrorTypes.PurchaseExceedsCurrency);
            }

            if (purchasePrice == 0)
            {
                return new ChangeCalculatorResponse(false, changeItems, ChangeCalculatorResponse.ErrorTypes.PurchasePriceNotProvided);
            }

            if (Decimal.Round(currencyAmount, 2) != currencyAmount
                || Decimal.Round(purchasePrice, 2) != purchasePrice)
            {
                return new ChangeCalculatorResponse(false, changeItems, ChangeCalculatorResponse.ErrorTypes.InvalidCurrencyAmount);
            }

            decimal changeAmount = currencyAmount - purchasePrice;

            foreach (CurrencyDenomination denomination in _Denominations.CurrencyDenominations)
            {
                if (changeAmount == 0) break;

                int denominationQuantity = 0;

                while (changeAmount >= denomination.Value)
                {
                    changeAmount -= denomination.Value;
                    denominationQuantity++;
                }
             
                if (denominationQuantity > 0)
                {
                    changeItems.Add(new ChangeItem(denomination, denominationQuantity));
                }
            }

            return new ChangeCalculatorResponse(true, changeItems);
        }

    }
}
