using ChangeCalculator.Core.Domain;
using ChangeCalculator.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
        [InlineData(50, 10, true, StatusCodes.Status200OK)]
        [InlineData(10, 50, false, StatusCodes.Status400BadRequest)]
        public void ChangeController_Get_ReturnsOk(decimal currencyAmount, decimal purchasePrice, bool successFlag, int statusCode)
        {
            // arrange
            var result = new ChangeCalculatorResult() { Success = successFlag };
            ChangeCalculatorMock.Setup(c => c.Process(currencyAmount, purchasePrice)).Returns(result).Verifiable();

            // act

            var actionResult = ChangeController.Get(currencyAmount, purchasePrice);
            var statusCodeResult = actionResult as IStatusCodeActionResult;

            // assert
            Assert.NotNull(statusCodeResult);
            Assert.Equal(statusCode, statusCodeResult.StatusCode);
            ChangeCalculatorMock.VerifyAll();
        }
    }
}
