using ChangeCalculator.Core.Domain;
using ChangeCalculator.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ChangeCalculator.WebAPI.Controllers
{
    public class ChangeControllerTests
    {
        ChangeController ChangeController = null;

        Mock<IChangeCalculator> ChangeCalculatorMock = null;

        public ChangeControllerTests()
        {
            ChangeCalculatorMock = new Mock<IChangeCalculator>();

            ChangeController = new ChangeController(ChangeCalculatorMock.Object);
        }

        [Theory]
        [InlineData(50, 10)]
        public void ChangeController_Get_ReturnsOk(decimal currencyAmount, decimal purchasePrice)
        {
            // arrange
            var result = new ChangeCalculatorResult() { Success = true };
            ChangeCalculatorMock.Setup(c => c.Process(currencyAmount, purchasePrice)).Returns(result).Verifiable();

            // act

            var actionResult = ChangeController.Get(currencyAmount, purchasePrice);
   
            // assert
            Assert.True(actionResult is OkObjectResult);
            ChangeCalculatorMock.VerifyAll();
        }
    }
}
