using Microsoft.AspNetCore.Mvc;

namespace SMTC.API.TaxaJuros.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaJurosController : ControllerBase
    {
        [HttpGet]
        public double Get()
        {
            return 0.01;
        }
    }
}
