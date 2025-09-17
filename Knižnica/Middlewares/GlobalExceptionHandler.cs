using System.Net;
using System.Text.Json;
using Domain.Exceptions;

namespace Knižnica.Middlewares;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    private readonly ILogger<GlobalExceptionHandler> _logger = logger;


    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex, HttpStatusCode.BadRequest);
        }
    }

    public async Task HandleException(HttpContext context, Exception ex, HttpStatusCode statusCode)
    {
        HttpResponse response = context.Response;
        _logger.LogError(ex, ex.Message);
        response.StatusCode = (int)statusCode;
        response.ContentType = "application/json";

        
        
        var handledError = new GlobalExceptionDto()
        {
            Message = ex.Message,
            StackTrace = ex.StackTrace,
            Source = ex.Source,
            StatusCode = context.Response.StatusCode,
        };

        var serializedError = JsonSerializer.Serialize(handledError);

        await response.WriteAsJsonAsync(serializedError);
        
    }
}
