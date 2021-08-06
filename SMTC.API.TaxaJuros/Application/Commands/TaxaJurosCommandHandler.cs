using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SMTC.API.TaxaJuros.Application.Commands
{
    public class TaxaJurosCommandHandler : AsyncRequestHandler<TaxaJurosUpdateCommand>
    {
        protected override async Task Handle(TaxaJurosUpdateCommand request, CancellationToken cancellationToken)
        {
            await Task.FromResult(0);
        }
    }
}
