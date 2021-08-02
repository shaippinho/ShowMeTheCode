using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace SMTC.Core.Controllers
{
    [ApiController]
    [CustomError]
    public abstract class BaseController : ControllerBase
    {
        protected ICollection<string> Error = new List<string>();

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation())
            {
                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]> {
                {"Message", Error.ToArray()}
            })
            {
                Title = "Erro"
            });

        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddErrorProcessing(error.ErrorMessage);
            }

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {

            var error = modelState.Values.SelectMany(e => e.Errors);

            foreach (var erro in error)
            {
                AddErrorProcessing(erro.ErrorMessage);
            }

            return CustomResponse();
        }

        protected bool ValidOperation()
        {
            return !Error.Any();
        }

        protected void AddErrorProcessing(string error)
        {
            Error.Add(error);
        }

        protected void ClearErrorProccessing()
        {
            Error.Clear();
        }
    }
}
