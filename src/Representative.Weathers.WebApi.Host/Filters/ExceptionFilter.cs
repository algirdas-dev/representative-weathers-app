using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Representative.Weathers.WebApi.Contracts;
using Representative.Weathers.WebApi.Domain.Exceptions;

namespace Representative.Weathers.WebApi.Host.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType().IsSubclassOf(typeof(ExceptionBase<NotFound>)))
            {
                context.Result = new ObjectResult((context.Exception as ExceptionBase<NotFound>)?.Error)
                {
                    StatusCode = 404
                };
            }
            else
            {
                context.Result = new ObjectResult(new InternalServerError()
                {
                    Code = "ErrorOccurred",
                    Message = "An error occurred"
                })
                {
                    StatusCode = 500
                };
            }

            context.ExceptionHandled = true;
        }
    }
}