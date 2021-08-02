using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Linq;

namespace SMTC.Core.Controllers
{
    public class CustomErrorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (!context.ModelState.IsValid)
            {
                var validatonObject = (CustomErrorModel)(new ValidationFailedResult(context.ModelState).Value);

                var json = JsonConvert.SerializeObject(validatonObject, new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() });

                context.Result = new ContentResult { Content = json, ContentType = "application/json", StatusCode = validatonObject.status };
            }
        }
    }

    public class ValidationFailedResult : ObjectResult
    {
        public ValidationFailedResult(ModelStateDictionary modelState)
            : base(new CustomErrorModel(modelState))
        {
            StatusCode = StatusCodes.Status400BadRequest;
        }
    }

    public class CustomErrorModel
    {
        public CustomErrorModelMessage errors;
        public string title { get; }
        public int status { get; }

        public CustomErrorModel(ModelStateDictionary modelState)
        {
            errors = new CustomErrorModelMessage
            {
                Message = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => "Dados inválidos"))
                    .ToArray()
            };

            title = "Erro";

            status = StatusCodes.Status400BadRequest;
        }

        public CustomErrorModel(System.Exception ex)
        {
            errors = new CustomErrorModelMessage
            {
                Message = new string[] { ex.Message },
            };

            title = "Erro";

            status = StatusCodes.Status500InternalServerError;
        }

        public override string ToString()
        {
           return JsonConvert.SerializeObject(this, new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() });
        }
    }

    public class CustomErrorModelMessage
    {
        public string[] Message { get; set; }
    }
}
