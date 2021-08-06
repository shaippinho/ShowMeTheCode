using FluentValidation;
using MediatR;

namespace SMTC.API.TaxaJuros.Application.Commands
{
    public class TaxaJurosUpdateCommand : IRequest
    {
        public double taxaJuros { get; set; }

        public TaxaJurosUpdateCommand(double taxaJuros)
        {
            this.taxaJuros = taxaJuros;
        }

        //Factory Method
        public static TaxaJurosUpdateCommand Create(double taxaJuros)
           => new(taxaJuros);
    }

    public class TaxaJurosUpdateValidation : AbstractValidator<TaxaJurosUpdateCommand>
    {
        public TaxaJurosUpdateValidation()
        {
            RuleFor(c => c.taxaJuros)
               .NotNull()
               .WithMessage("Taxa de Juros não pode ser vazio")
               .DependentRules(() =>
               {
                   RuleFor(x => x.taxaJuros)
                   .GreaterThan(0)
                   .WithMessage("Taxa de Juros tem que ser maior que zero");
               });
        }
    }
}
