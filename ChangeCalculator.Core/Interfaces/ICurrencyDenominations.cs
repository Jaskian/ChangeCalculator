using ChangeCalculator.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCalculator.Core.Interfaces
{
    public interface ICurrencyDenominations
    {
        IReadOnlyList<CurrencyDenomination> CurrencyDenominations { get; }
    }
}
