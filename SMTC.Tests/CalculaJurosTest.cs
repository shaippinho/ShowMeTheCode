using Moq;
using SMTC.API.CalculaJuros.Application.Interfaces;
using SMTC.API.CalculaJuros.Application.Services;
using SMTC.API.CalculaJuros.Controllers;
using SMTC.API.CalculaJuros.Interfaces;
using SMTC.Core.Notification;
using System;
using Xunit;

namespace SMTC.Tests
{
    public class CalculaJurosTest
    {
        [Fact(DisplayName = "Controller Get Calcula Juros")]
        public async void Controller_Get_Calcula_Juros()
        {
            //Arrange
            var mockIDomainNotificationContext = new Mock<IDomainNotificationContext>();
            var mockICalculaJurosService = new Mock<ICalculaJurosService>();
            mockICalculaJurosService.Setup(x => x.Calculo(100, 5)).ReturnsAsync(105.10);

            var calculaJurosController = new CalculaJurosController(
                mockICalculaJurosService.Object,
                mockIDomainNotificationContext.Object
                );

            //Act
            var result = await calculaJurosController.Get(100, 5);

            //Assert
            Assert.IsAssignableFrom<double>(result);
            Assert.Equal(105.10, result);
        }

        [Theory(DisplayName = "Service Calcula Juros")]
        [InlineData(100,5)]
        [InlineData(200,4)]
        [InlineData(300,2)]
        [InlineData(500,1)]
        public async void Service_Get_Calcula_Juros(double valorInicial, int meses)
        {
            //Arrange
            var mockITaxaJuros = new Mock<ITaxaJuros>();
            var taxaJuros = new Random().NextDouble();
            mockITaxaJuros.Setup(x => x.GetTaxaJuros()).ReturnsAsync(taxaJuros);
            var mockCalculaJurosService = new CalculaJurosService(mockITaxaJuros.Object);

            //Act
            var result = await mockCalculaJurosService.Calculo(valorInicial, meses);
            var expected = Calculo(valorInicial, meses, taxaJuros);
            //Assert
            Assert.Equal(expected, result);
        }

        private double Calculo(double valorInicial, int meses, double taxaJuros)
        {
            var result = Math.Pow((1 + taxaJuros), meses);
            result = valorInicial * result;
            return Math.Round(result, 2);
        }
    }
}
