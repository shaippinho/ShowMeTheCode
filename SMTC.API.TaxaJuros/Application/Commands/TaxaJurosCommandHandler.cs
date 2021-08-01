using FluentValidation.Results;
using MediatR;
using SMTC.Core.MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SMTC.API.TaxaJuros.Application.Commands
{
    public class TaxaJurosCommandHandler : CommandHandler, IRequestHandler<TaxaJurosUpdateCommand, ValidationResult>
    {
        public async Task<ValidationResult> Handle(TaxaJurosUpdateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            return request.ValidationResult;
        }
    }
}
