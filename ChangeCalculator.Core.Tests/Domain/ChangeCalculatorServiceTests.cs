using ChangeCalculator.Core.Interfaces;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChangeCalculator.Core.Domain
{
    public class ChangeCalculatorServiceTests
    {
        ChangeCalculatorService service;
        Mock<ICurrencyDenominations> currencyDenominations;

        public ChangeCalculatorServiceTests()
        {
            currencyDenominations = new Mock<ICurrencyDenominations>();

            service = new ChangeCalculatorService(currencyDenominations.Object);
        }

        [Fact]
        public void ReturnsNoChangeWhenPurchaseMatchesCurrency()
        {
            // arrange

            // act
            var response = service.Process(50, 50);

            // assert
            response.Should().NotBeNull();
            response.ChangeItems.Should().NotBeNull();
            response.ChangeItems.Should().BeEmpty();
        }
    }
}
