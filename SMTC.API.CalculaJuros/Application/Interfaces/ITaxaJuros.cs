using Refit;
using System.Threading.Tasks;

namespace SMTC.API.CalculaJuros.Interfaces
{
    public interface ITaxaJuros
    {
        [Get("/TaxaJuros")]
        Task<double> GetTaxaJuros();
    }
}
