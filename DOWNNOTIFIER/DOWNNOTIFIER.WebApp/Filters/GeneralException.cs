using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using DOWNNOTIFIER.WebApp.Helpers;
using System.Reflection;

namespace DOWNNOTIFIER.WebApp.Filters
{
    public class GeneralException : IExceptionFilter
    {
        public record BasicErrorHttpResponse(string Message, HttpStatusCode StatusCode);

        public void OnException(ExceptionContext context)
        {
            new ErrorLogger(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).WriteErrorLog(context.Exception);
        }
    }
}
