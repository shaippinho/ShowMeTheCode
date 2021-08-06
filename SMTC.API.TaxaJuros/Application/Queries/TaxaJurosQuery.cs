using MediatR;
using SMTC.API.TaxaJuros.Application.DTO;

namespace SMTC.API.TaxaJuros.Application.Queries
{
    public class TaxaJurosQuery : IRequest<TaxaJurosDTO>
    {
        public TaxaJurosQuery(int tipo)
        {
            Tipo = tipo;
        }

        public int Tipo { get; protected set; }

        public static TaxaJurosQuery Create(int tipo)
            => new(tipo);
    }
}
