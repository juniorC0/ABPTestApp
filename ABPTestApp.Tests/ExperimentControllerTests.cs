using ABPTestApp.Application.Interfaces;
using ABPTestApp.Domain;
using APBTestApp.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ABPTestApp.Tests
{
    [TestClass]
    public class ExperimentControllerTests
    {
        private readonly Mock<IExperimentService> _mockExperimentService;
        private readonly ExperimentController _controller;

        public ExperimentControllerTests()
        {
            _mockExperimentService = new Mock<IExperimentService>();
            _controller = new ExperimentController(_mockExperimentService.Object);
        }

        [TestMethod]
        public async Task GetButtonColor_ReturnsOkWithCorrectResult()
        {
            // Arrange
            var deviceToken = "test_token";
            var experiment = new Experiment { Name = "button_color", Option = "#00FF00" };
            _mockExperimentService.Setup(s => s.GetButtonColorAsync(deviceToken)).ReturnsAsync(experiment);
            var expected = new Dictionary<string, string>() { { "key", "button_color" }, { "value", "#00FF00" } };

            // Act
            var result = await _controller.GetButtonColor(deviceToken);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var actual = okResult.Value as Dictionary<string, string>;
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected["key"], actual["key"]);
            Assert.AreEqual(expected["value"], actual["value"]);
        }

        [TestMethod]
        public async Task GetButtonColor_ReturnsBadRequestWhenDeviceTokenIsNullOrEmpty()
        {
            // Arrange
            var deviceToken = "";

            // Act
            var result = await _controller.GetButtonColor(deviceToken);

            // Assert
            var badRequestResult = result as BadRequestResult;
            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual(400, badRequestResult.StatusCode);
        }

        [TestMethod]
        public async Task GetButtonColor_ReturnsNotFoundWhenExperimentIsNull()
        {
            // Arrange
            var deviceToken = "test_token";
            _mockExperimentService.Setup(s => s.GetButtonColorAsync(deviceToken)).ReturnsAsync((Experiment)null);

            // Act
            var result = await _controller.GetButtonColor(deviceToken);

            // Assert
            var notFoundResult = result as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
        }

        [TestMethod]
        public async Task GetPrice_ReturnsOkResultWithData()
        {
            // Arrange
            var deviceToken = "test_token";
            var experiment = new Experiment { Name = "price", Option = "10" };
            _mockExperimentService.Setup(s => s.GetPriceAsync(deviceToken)).ReturnsAsync(experiment);

            // Act
            var result = await _controller.GetPrice(deviceToken);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);

            var data = okResult.Value as Dictionary<string, string>;
            Assert.IsNotNull(data);
            Assert.AreEqual("price", data["key"]);
            Assert.AreEqual("10", data["value"]);
        }

        [TestMethod]
        public async Task GetPrice_ReturnsBadRequestWhenDeviceTokenIsNullOrEmpty()
        {
            // Arrange
            var deviceToken = "";

            // Act
            var result = await _controller.GetPrice(deviceToken);

            // Assert
            var badRequestResult = result as BadRequestResult;
            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual(400, badRequestResult.StatusCode);
        }

        [TestMethod]
        public async Task GetPrice_ReturnsNotFoundWhenExperimentIsNull()
        {
            // Arrange
            var deviceToken = "test_token";
            _mockExperimentService.Setup(s => s.GetPriceAsync(deviceToken)).ReturnsAsync((Experiment)null);

            // Act
            var result = await _controller.GetPrice(deviceToken);

            // Assert
            var notFoundResult = result as NotFoundResult;
            Assert.IsNotNull(notFoundResult);
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }
    }
}