using Microsoft.AspNetCore.Mvc;
using SMTC.API.CalculaJuros.Interfaces;
using System;
using System.Threading.Tasks;

namespace SMTC.API.CalculaJuros.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ITaxaJuros _taxaJuros;

        public CalculaJurosController(ITaxaJuros taxajuros)
        {
            _taxaJuros = taxajuros;
        }

        [HttpGet]
        public async Task<double> Get(double valorInicial, int meses)
        {
            var taxaJuros = await _taxaJuros.GetTaxaJuros();
            var result = Math.Pow((1 + taxaJuros), meses);
            result = valorInicial * result;
            return Math.Round(result, 2);
        }
    }
}
