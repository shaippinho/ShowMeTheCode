using SMTC.API.TaxaJuros.Application.DTO;
using SMTC.API.TaxaJuros.Application.Interfaces;
using System.Threading.Tasks;

namespace SMTC.API.TaxaJuros.Application.Queries
{
    public class TaxaJurosQuery : ITaxaJurosQuery
    {
        public async Task<TaxaJurosDTO> GetTaxa()
        {
            return await Task.Run(() =>
            {
                return new TaxaJurosDTO(){ taxaJuros = 0.01 };
            });
        }
    }
}
