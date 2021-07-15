using Moq;
using SMTC.API.CalculaJuros.Application.Interfaces;
using SMTC.API.CalculaJuros.Controllers;
using Xunit;

namespace SMTC.Tests
{
    public class CalculaJurosControllerTest
    {
        [Fact(DisplayName = "Get Calcula Juros")]
        public async void Get_Calcula_Juros()
        {
            //Arrange
            var mockICalculaJurosService = new Mock<ICalculaJurosService>();
            mockICalculaJurosService.Setup(x => x.Calculo(100, 5)).ReturnsAsync(105.10);

            var calculaJurosController = new CalculaJurosController(
                mockICalculaJurosService.Object
                );

            //Act
            var result = await calculaJurosController.Get(100, 5);

            //Assert
            Assert.IsAssignableFrom<double>(result);
            Assert.Equal(105.10, result);
        }

    }
}
