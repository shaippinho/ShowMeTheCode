using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMTC.API.TaxaJuros.Application.Commands;
using SMTC.API.TaxaJuros.Application.Interfaces;
using SMTC.Core.Controllers;
using System.Net;
using System.Threading.Tasks;

namespace SMTC.API.TaxaJuros.Controllers
{
    [Route("[controller]")]
    public class TaxaJurosController : BaseController
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
        public async Task<IActionResult> Calcular([FromBody] double taxaJuros)
        {
            var response = await _mediator.Send(new TaxaJurosUpdateCommand(taxaJuros));
            return CustomResponse(response);
        }
    }
}
