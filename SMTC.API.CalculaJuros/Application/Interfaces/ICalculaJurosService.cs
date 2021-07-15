using System.Threading.Tasks;

namespace SMTC.API.CalculaJuros.Application.Interfaces
{
    public interface ICalculaJurosService
    {
        Task<double> Calculo(double valorInicial, int meses);
    }
}
