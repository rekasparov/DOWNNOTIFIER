using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DOWNNOTIFIER.WebApp.Filters
{
    public class GeneralException : IExceptionFilter
    {
        public record BasicErrorHttpResponse(string Message, HttpStatusCode StatusCode);

        public void OnException(ExceptionContext context)
        {
            var exception = new BasicErrorHttpResponse(context.Exception.Message, HttpStatusCode.InternalServerError);

            context.Result = new ObjectResult(exception)
            {
                StatusCode = (int)exception.StatusCode
            };
        }
    }
}
