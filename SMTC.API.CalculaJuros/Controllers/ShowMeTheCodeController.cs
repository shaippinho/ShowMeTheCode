using Microsoft.AspNetCore.Mvc;

namespace SMTC.API.CalculaJuros.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShowMeTheCodeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "https://github.com/shaippinho/ShowMeTheCode";
        }
    }
}
