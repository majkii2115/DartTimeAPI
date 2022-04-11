using System.Net;
using System.Text.Json;
using DartTimeAPI.Errors;

namespace DartTimeAPI.Middleware;
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private IHostEnvironment _env;
    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
    {
        _next = next;
        _env = env;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, exception.Message);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) (HttpStatusCode.InternalServerError);
            var response = _env.IsDevelopment() ? new ApiException(context.Response.StatusCode, exception.Message, exception.StackTrace?.ToString()) : 
            new ApiException(context.Response.StatusCode, "Internal server error.");
            
            var json = JsonSerializer.Serialize(response, new JsonSerializerOptions {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            await context.Response.WriteAsync(json);
        }
    }
}
