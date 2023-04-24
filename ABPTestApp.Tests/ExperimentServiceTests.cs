using ABPTestApp.Application.Interfaces;
using ABPTestApp.Application.Services;
using ABPTestApp.Domain;
using Moq;

namespace ABPTestApp.Tests
{
    [TestClass]
    public class ExperimentServiceTests
    {
        private Mock<IRepository> _mockRepository;
        private ExperimentService _experimentService;

        public ExperimentServiceTests()
        {
            _mockRepository = new Mock<IRepository>();
            _experimentService = new ExperimentService(_mockRepository.Object);
        }

        [TestMethod]
        public async Task GetButtonColorAsync_CreatesNewDeviceWithRandomExperiment()
        {
            // Arrange
            var deviceToken = "test_token";
            var colorExperiments = new List<Experiment>
        {
            new Experiment { Id = 1, Name = "button-color", Option = "#00FF00" },
            new Experiment { Id = 2, Name = "button-color", Option = "#0000FF" }
        };
            _mockRepository.Setup(r => r.GetExperimentsByNameAsync("button-color")).ReturnsAsync(colorExperiments);
            _mockRepository.Setup(r => r.GetAllAsync<Device>()).ReturnsAsync(new List<Device>());

            // Act
            var result = await _experimentService.GetButtonColorAsync(deviceToken);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("button-color", result.Name);
            Assert.IsTrue(colorExperiments.Any(x => x.Option == result.Option));
            _mockRepository.Verify(r => r.AddAsync(It.IsAny<Device>()), Times.Once);
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [TestMethod]
        public async Task GetPriceAsync_ReturnsExistingDeviceExperiment()
        {
            // Arrange
            var deviceToken = "test_token";
            var experiment = new Experiment() { Id = 1, Name = "price", Option = "$100" };
            var device = new Device() { Id = 1, Token = deviceToken, Experiment = experiment, ExperimentId = experiment.Id };
            _mockRepository.Setup(r => r.GetAllAsync<Device>()).ReturnsAsync(new List<Device> { device });

            // Act
            var result = await _experimentService.GetPriceAsync(deviceToken);

            // Assert
            Assert.AreEqual(experiment, result);
        }

        [TestMethod]
        public async Task GetPriceAsync_AddsNewDeviceWithRandomExperiment()
        {
            // Arrange
            var deviceToken = "test_token";
            var priceExperiments = new List<Experiment>
        {
            new Experiment { Id = 1, Name = "price", Option = "$100" },
            new Experiment { Id = 2, Name = "price", Option = "$200" },
            new Experiment { Id = 3, Name = "price", Option = "$500" },
            new Experiment { Id = 4, Name = "price", Option = "$1000" }
        };
            _mockRepository.Setup(r => r.GetExperimentsByNameAsync("price")).ReturnsAsync(priceExperiments);
            _mockRepository.Setup(r => r.GetAllAsync<Device>()).ReturnsAsync(new List<Device>());

            // Act
            var result = await _experimentService.GetPriceAsync(deviceToken);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(priceExperiments.Contains(result));
            _mockRepository.Verify(r => r.AddAsync(It.Is<Device>(d => d.Token == deviceToken && d.Experiment == result)), Times.Once);
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }
    }
}
