using FDCleanArchitecture.Application.Features.CarFeature.Commands.CreateCar;
using FDCleanArchitecture.Application.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FDCleanArchitecture.UnitTest
{
    public class CreateCommandHandlerUnitTest
    {
        private readonly Mock<ICarService> _carServiceMock;
        private readonly CreateCarCommandHandler _handler;

        public CreateCommandHandlerUnitTest()
        {
            _carServiceMock = new Mock<ICarService>();
            _handler = new CreateCarCommandHandler(_carServiceMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnSuccessMessage_WhenCarIsCreated()
        {
            // Arrange
            CreateCarCommand createCarCommand = new(
                "Toyota", "Corolla", 5000);

                

            _carServiceMock
                .Setup(service => service.CreateAsync(createCarCommand, It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(createCarCommand, CancellationToken.None);

            // Assert
            Assert.Equal("Araç başarılı bir şekilde oluşturuldu", result.Message);
            _carServiceMock.Verify(service => service.CreateAsync(createCarCommand, It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
