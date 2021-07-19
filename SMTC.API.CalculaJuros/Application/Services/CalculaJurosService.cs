using SMTC.API.CalculaJuros.Application.Interfaces;
using SMTC.API.CalculaJuros.Interfaces;
using System;
using System.Threading.Tasks;

namespace SMTC.API.CalculaJuros.Application.Services
{
    public class CalculaJurosService : ICalculaJurosService
    {
        private readonly ITaxaJuros _taxaJuros;

        public CalculaJurosService(ITaxaJuros taxajuros)
        {
            _taxaJuros = taxajuros;
        }

        public async Task<double> Calculo(double valorInicial, int meses)
        {
            var taxaJuros = await _taxaJuros.GetTaxaJuros();
            var result = Math.Pow((1 + taxaJuros), meses);
            result = valorInicial * result;
            return Math.Round(result, 2, MidpointRounding.AwayFromZero);
        }
    }
}
