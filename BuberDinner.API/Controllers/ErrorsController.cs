using BuberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.API.Controllers
{
    [ApiController]
    [Route("error")]
    public class ErrorsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            //var (statusCode, message) = exception switch
            //{
            //    IServiceExeption serviceExeption => ((int)serviceExeption.StatusCode, serviceExeption.ErrorMessage),
            //    _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred.")
            //};

            //return Problem(statusCode: statusCode, title: message);
            return Problem();
        }
    }
}
