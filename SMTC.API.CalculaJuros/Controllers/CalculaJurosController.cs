using Microsoft.AspNetCore.Mvc;
using SMTC.API.CalculaJuros.Application.Interfaces;
using SMTC.Core.Controllers;
using System.Threading.Tasks;

namespace SMTC.API.CalculaJuros.Controllers
{
    //[Route("[controller]")]
    public class CalculaJurosController : BaseController
    {
        private readonly ICalculaJurosService _calculaJurosService;

        public CalculaJurosController(ICalculaJurosService calculaJurosService)
        {
            _calculaJurosService = calculaJurosService;
        }

        [HttpGet("CalculaJuros")]
        public async Task<double> Get(double valorInicial, int meses)
        {
            return await _calculaJurosService.Calculo(valorInicial, meses);
        }

    }
}
