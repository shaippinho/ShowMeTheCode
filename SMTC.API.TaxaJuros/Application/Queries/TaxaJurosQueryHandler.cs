using MediatR;
using SMTC.API.TaxaJuros.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SMTC.API.TaxaJuros.Application.Queries
{
    public class TaxaJurosQueryHandler : IRequestHandler<TaxaJurosQuery, TaxaJurosDTO>
    {

        public async Task<TaxaJurosDTO> Handle(TaxaJurosQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                return new TaxaJurosDTO() { taxaJuros = (request.Tipo == 1) ? 0.01 : 0.02 };
            });
        }
    }
}
