using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMTC.API.TaxaJuros.Application.Commands;
using SMTC.API.TaxaJuros.Application.Queries;
using SMTC.Core.Controllers;
using SMTC.Core.Notification;
using System.Threading.Tasks;

namespace SMTC.API.TaxaJuros.Controllers
{
    [Route("[controller]")]
    public class TaxaJurosController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IDomainNotificationContext _notificationContext;
        public TaxaJurosController(
            IMediator mediator,
            IDomainNotificationContext notificationContext)
        {
            _mediator = mediator;
            _notificationContext = notificationContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int tipo = 1)
        {
            var query = TaxaJurosQuery.Create(tipo);
            var result = await _mediator.Send(query);
            return Ok(result.taxaJuros);
        }

        [HttpPut]
        public async Task<IActionResult> Calcular([FromBody] double taxaJuros)
        {
            await _mediator.Send(TaxaJurosUpdateCommand.Create(taxaJuros));

            if (_notificationContext.HasErrorNotifications) { return CustomResponse(_notificationContext.GetErrorNotifications()); }

            return Ok();
        }
    }
}
