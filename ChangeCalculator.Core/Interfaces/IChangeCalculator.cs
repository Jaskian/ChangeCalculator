using ChangeCalculator.Core.Domain;

namespace ChangeCalculator.Core.Interfaces
{
    public interface IChangeCalculator
    {
        ChangeCalculatorResult Process(decimal currencyAmount, decimal purchasePrice);
    }
}