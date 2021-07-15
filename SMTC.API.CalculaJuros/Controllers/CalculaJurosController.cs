using Microsoft.AspNetCore.Mvc;
using SMTC.API.CalculaJuros.Application.Interfaces;
using System.Threading.Tasks;

namespace SMTC.API.CalculaJuros.Controllers
{
    //[Route("[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
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

        [HttpGet("ShowMeTheCode")]
        public string Get()
        {
            return "https://github.com/shaippinho/ShowMeTheCode";
        }
    }
}
