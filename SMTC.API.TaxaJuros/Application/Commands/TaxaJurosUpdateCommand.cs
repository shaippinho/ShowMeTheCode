using SMTC.Core.MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace SMTC.API.TaxaJuros.Application.Commands
{
    public class TaxaJurosUpdateCommand : Command
    {
        public double taxaJuros { get; set; }

        public TaxaJurosUpdateCommand(double taxaJuros)
        {
            this.taxaJuros = taxaJuros;
        }

        public override bool IsValid()
        {
            ValidationResult = new TaxaJurosUpdateValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class TaxaJurosUpdateValidation : AbstractValidator<TaxaJurosUpdateCommand>
    {
        public TaxaJurosUpdateValidation()
        {
            RuleFor(c => c.taxaJuros)
               .NotNull()
               .WithMessage("Taxa de Juros não pode ser vazio");
        }
    }
}
