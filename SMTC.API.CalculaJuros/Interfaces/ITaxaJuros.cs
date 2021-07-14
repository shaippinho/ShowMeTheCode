using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMTC.API.CalculaJuros.Interfaces
{
    public interface ITaxaJuros
    {
        [Get("/TaxaJuros")]
        Task<double> GetTaxaJuros();
    }
}
