using Moq;
using SMTC.API.CalculaJuros.Controllers;
using SMTC.API.CalculaJuros.Interfaces;
using Xunit;

namespace SMTC.Tests
{
    public class CalculaJurosControllerTest
    {
        [Fact(DisplayName = "Get Calcula Juros")]
        public async void Get_Calcula_Juros()
        {
            //Arrange
            var mockITaxaJuros = new Mock<ITaxaJuros>();
            mockITaxaJuros.Setup(x => x.GetTaxaJuros()).ReturnsAsync(0.01);

            var calculaJurosController = new CalculaJurosController(
                mockITaxaJuros.Object
                );

            //Act
            var result = await calculaJurosController.Get(100, 5);

            //Assert
            Assert.IsAssignableFrom<double>(result);
            Assert.Equal(105.10, result);
        }

    }
}
