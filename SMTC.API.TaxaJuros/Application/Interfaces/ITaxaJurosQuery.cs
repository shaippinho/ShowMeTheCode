using SMTC.API.TaxaJuros.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMTC.API.TaxaJuros.Application.Interfaces
{
    public interface ITaxaJurosQuery
    {
        Task<TaxaJurosDTO> GetTaxa();
    }
}
