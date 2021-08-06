using Microsoft.AspNetCore.Mvc;
using SMTC.API.CalculaJuros.Application.Interfaces;
using SMTC.Core.Controllers;
using SMTC.Core.Notification;
using System.Threading.Tasks;

namespace SMTC.API.CalculaJuros.Controllers
{
    //[Route("[controller]")]
    public class CalculaJurosController : BaseController
    {
        private readonly ICalculaJurosService _calculaJurosService;
        private readonly IDomainNotificationContext _notificationContext;

        public CalculaJurosController(ICalculaJurosService calculaJurosService, 
            IDomainNotificationContext notificationContext)
        {
            _calculaJurosService = calculaJurosService;
            _notificationContext = notificationContext;
        }

        [HttpGet("CalculaJuros")]
        public async Task<double> Get(double valorInicial, int meses)
        {
            return await _calculaJurosService.Calculo(valorInicial, meses);
        }

    }
}
