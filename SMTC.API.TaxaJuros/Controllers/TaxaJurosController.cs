using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMTC.API.TaxaJuros.Application.Commands;
using SMTC.API.TaxaJuros.Application.Interfaces;
using System.Net;
using System.Threading.Tasks;

namespace SMTC.API.TaxaJuros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaJurosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITaxaJurosQuery _taxaJurosQuery;
        public TaxaJurosController(
            IMediator mediator,
            ITaxaJurosQuery taxaJurosQuery)
        {
            _mediator = mediator;
            _taxaJurosQuery = taxaJurosQuery;
        }

        [HttpGet]
        public async Task<double> Get()
        {
            return (await _taxaJurosQuery.GetTaxa()).taxaJuros;
        }

        [HttpPut]
        [ProducesResponseType(typeof(ValidationResult), (int)HttpStatusCode.OK)]
        public async Task<ValidationResult> Calcular([FromBody] double taxaJuros)
        {
            return await _mediator.Send(new TaxaJurosUpdateCommand(taxaJuros));
        }
    }
}
