using ChangeCalculator.Core.Domain.Models;
using ChangeCalculator.Core.Domain.Response;
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
            response.Error.Should().BeNull();
        }

        [Theory]
        [InlineData(40, 50, ChangeCalculatorResponse.ErrorTypes.PurchaseExceedsCurrency)]
        [InlineData(50, 0, ChangeCalculatorResponse.ErrorTypes.PurchasePriceNotProvided)]
        public void ReturnsInputValidationErrors(decimal currencyAmount, decimal purchasePrice, ChangeCalculatorResponse.ErrorTypes expectedError)
        {
            // arrange

            // act
            var response = service.Process(currencyAmount, purchasePrice);

            // assert
            response.Should().NotBeNull();
            response.ChangeItems.Should().BeEmpty();

            response.Success.Should().BeFalse("Purchase Exceeded Currency");
            response.Error.Should().Be(expectedError);
        }

        [Theory]
        [InlineData(200, 50, 3)]
        [InlineData(100, 50, 1)]
        public void SingleDenominationChangeCalculation(decimal currencyAmount, decimal purchasePrice, int quantity)
        {
            // arrange
            currencyDenominations.Setup(c => c.CurrencyDenominations).Returns(new List<CurrencyDenomination>() { new CurrencyDenomination(50, "£50")  });

            // act
            var response = service.Process(currencyAmount, purchasePrice);

            // assert
            response.Should().NotBeNull();
            response.Success.Should().BeTrue();
            response.ChangeItems.Should().NotBeEmpty();
            response.ChangeItems.Should().ContainSingle();
            response.ChangeItems.First().Quantity.Should().Be(quantity);
        }

        [Theory]
        [InlineData(190, 50, 2, 2)]
        [InlineData(120, 50, 1, 1)]
        public void MultipleDenominationsChangeCalculation(decimal currencyAmount, decimal purchasePrice, int quantityOfFirstDenom, int quantityOfSecondDenom)
        {
            // arrange
            currencyDenominations.Setup(c => c.CurrencyDenominations).Returns(new List<CurrencyDenomination>() { new CurrencyDenomination(50, "£50"), new CurrencyDenomination(20, "£20"), });

            // act
            var response = service.Process(currencyAmount, purchasePrice);

            // assert
            response.Should().NotBeNull();
            response.Success.Should().BeTrue();
            response.ChangeItems.Should().NotBeEmpty();
            response.ChangeItems.Should().HaveCount(2);
            response.ChangeItems.ElementAt(0).Quantity.Should().Be(quantityOfFirstDenom);
            response.ChangeItems.ElementAt(1).Quantity.Should().Be(quantityOfSecondDenom);
        }

        [Theory]
        [InlineData(70, 50, 1)]
        [InlineData(90, 50, 2)]
        public void ShouldSkipLargerDenomination(decimal currencyAmount, decimal purchasePrice, int quantityOfSecondDenom)
        {
            // arrange
            currencyDenominations.Setup(c => c.CurrencyDenominations).Returns(new List<CurrencyDenomination>() { new CurrencyDenomination(50, "£50"), new CurrencyDenomination(20, "£20"), });

            // act
            var response = service.Process(currencyAmount, purchasePrice);

            // assert
            response.Should().NotBeNull();
            response.Success.Should().BeTrue();
            response.ChangeItems.Should().NotBeEmpty();
            response.ChangeItems.Should().ContainSingle();
            response.ChangeItems.ElementAt(0).Quantity.Should().Be(quantityOfSecondDenom);
        }
    }
}
