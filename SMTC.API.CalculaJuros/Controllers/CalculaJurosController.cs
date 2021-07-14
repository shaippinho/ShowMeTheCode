using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Refit;
using SMTC.API.CalculaJuros.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //var taxaJuros = RestService.For<double>("");
            var taxaJuros = await _taxaJuros.GetTaxaJuros();
            var result = Math.Pow((valorInicial * (1 + taxaJuros)), meses);
            return Math.Round(result, 2);
        }
    }
}
