using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChangeCalculator.Core.Domain.Currency
{
    public class EnglishPoundDenominationsTests
    {
        EnglishPoundDenominations englishPoundDenominations = null;

        public EnglishPoundDenominationsTests()
        {
            englishPoundDenominations = new EnglishPoundDenominations();
        }

        [Fact]
        public void ReturnsTwelveItems()
        {
            // arrange
            // act
            var denominations = englishPoundDenominations.CurrencyDenominations;
            // assert
            Assert.Equal(12, denominations.Count);
        }

        [Fact]
        public void ReturnsBiggestToSmallest()
        {
            // arrange
            // act
            var denominations = englishPoundDenominations.CurrencyDenominations;

            // assert

            denominations.Should().BeInDescendingOrder(c => c.Value);          
        }
    }
}
