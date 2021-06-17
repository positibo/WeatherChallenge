using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using WeatherChallenge.Source.Domain.BusinessRules;
using WeatherChallenge.Source.Domain.Interfaces;
using WeatherChallenge.Source.Domain.Models;
using WeatherChallenge.Source.Domain.UseCases.CanUserFlyKite;
using WeatherChallenge.Source.Domain.UseCases.CanUserShouldGoOutside;
using WeatherChallenge.Source.Domain.UseCases.CanUserShouldWearSunscreen;

namespace WeatherChallenge.Tests
{
    [TestClass]
    public class CanUserFlyKiteTest
    {
        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public async Task CanUserFlyKite_NotFound()
        {
            // setup mock data management for dependency injection
            var mockDataManagement = new Mock<IWeatherStackDataManagement>();
            mockDataManagement.Setup(o => o.GetWeatherInfo(It.IsAny<string>()))
               .Returns<string>((type) => Task.FromResult(new WeatherData()));

            var zipCode = "95501";
            var command = new CanUserFlyKiteCommand(zipCode);
            var handler = new CanUserFlyKiteCommand.CanUserFlyKiteCommandHandler(mockDataManagement.Object);

            // execute use case
            await handler.Handle(command, new CancellationToken());
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public async Task CanUserShouldGoOutside_NotFound()
        {
            // setup mock data management for dependency injection
            var mockDataManagement = new Mock<IWeatherStackDataManagement>();

            var zipCode = "95501";
            var command = new CanUserShouldGoOutsideCommand(zipCode);
            var handler = new CanUserShouldGoOutsideCommand.CanUserShouldGoOutsideCommandHandler(mockDataManagement.Object);

            // execute use case
            await handler.Handle(command, new CancellationToken());
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public async Task CanUserShouldWearSunscreen_NotFound()
        {
            // setup mock data management for dependency injection
            var mockDataManagement = new Mock<IWeatherStackDataManagement>();

            var zipCode = "95501";
            var command = new CanUserShouldWearSunscreenCommand(zipCode);
            var handler = new CanUserShouldWearSunscreenCommand.CanUserShouldWearSunscreenCommandHandler(mockDataManagement.Object);

            // execute use case
            await handler.Handle(command, new CancellationToken());
        }
    }
}
