using aplication.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace VeggieLink.Api.Extensions;

public class ExceptionFilter : IExceptionFilter
{
    private readonly ILogger<ExceptionFilter> _logger;
    public ExceptionFilter(ILogger<ExceptionFilter> logger)
    {
        _logger = logger;
    }
    public void OnException(ExceptionContext context)
    {
        _logger.LogError(context.Exception, "Excpetion tratada");
        switch (context.Exception)
        {
            case CustomException customEx:
                TratarErro(((int)customEx.StatusCode), customEx.Obj, context);
                return;
            default:
                var ex = context.Exception;
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Production")
                {
                    TratarErro(500,
                        new { erro = ex.Message, innerException = ex.InnerException?.Message, ex.StackTrace },
                        context);
                }
                else
                {
                    TratarErro(500, new { erro = "Erro inesperado" }, context);
                }
                return;
        }
    }

    private static void TratarErro(int statusCode, object obj, ExceptionContext context)
    {
        context.Result = new JsonResult(obj)
        {
            StatusCode = statusCode,
            ContentType = "application/json"
        };
    }
}