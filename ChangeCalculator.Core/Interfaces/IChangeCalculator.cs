using ChangeCalculator.Core.Domain;
using ChangeCalculator.Core.Domain.Response;

namespace ChangeCalculator.Core.Interfaces
{
    public interface IChangeCalculator
    {
        ChangeCalculatorResponse Process(decimal currencyAmount, decimal purchasePrice);
    }
}