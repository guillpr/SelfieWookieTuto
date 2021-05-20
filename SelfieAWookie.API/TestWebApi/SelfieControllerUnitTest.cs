using Microsoft.AspNetCore.Mvc;
using SelfieAWookie.API.Controllers;
using System;
using Xunit;

namespace TestWebApi
{
    public class SelfieControllerUnitTest
    {
        #region Public methods

        [Fact]
        public void ShouldReturnListOfSelfies()
        {
            // ARRANGE
            var controller = new SelfiesController(null);

            // ACT
            var result = controller.GetAll();

            //ASSERT
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            OkObjectResult okResult = result as OkObjectResult;
            Assert.NotNull(okResult.Value);
        }

        #endregion Public methods
    }
}