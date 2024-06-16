using FDCleanArchitecture.Application.Features.CarFeature.Commands.CreateCar;
using FDCleanArchitecture.Domain.Dtos;
using FDCleanArchitecture.Presentation.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FDCleanArchitecture.UnitTest
{
    public class CarsControllerUnitTest
    {
        [Fact]
        public async void Create_ReturnsOkResult_WhenRequestIsValid()
        {
            //metot isimlendirmesi metot ismi dönüþ deðeri ve validse kontrol edileceðini belirtme þeklinde best practice olarak yazýlýr
            //Arrange
            var mediatorMock = new Mock<IMediator>();
            CreateCarCommand createCarCommand = new(
                "Toyota", "Corolla", 5000);
            MessageResponse response = new("Araç baþarýlý bir þekilde oluþturuldu");
            CancellationToken cancellationToken = new();

            mediatorMock.Setup(m => m.Send(createCarCommand, cancellationToken)).ReturnsAsync(response);

            CarsController carsController = new(mediatorMock.Object);


            //Act
            var result = await carsController.Create(createCarCommand, cancellationToken);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue=Assert.IsType<MessageResponse>(okResult.Value);

            Assert.Equal(response, returnValue);
            mediatorMock.Verify(m=>m.Send(createCarCommand,cancellationToken),
                Times.Once());
        }
    }
}