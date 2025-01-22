using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BuberDinner.API.Filters
{
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var problemDetalis = new ProblemDetails
            {
                //Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Title = "An error occured while processing your request",
                Status = (int)HttpStatusCode.InternalServerError,
            };


            context.Result = new ObjectResult(problemDetalis);
           
            context.ExceptionHandled = true;
            
        }
    }
}
