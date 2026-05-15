using Api.Errors;
using System.Text.Json;

namespace Api.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AppException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ex.StatusCode;

                var error = new ErrorDetails
                {
                    StatusCode = ex.StatusCode,
                    Message = ex.Message,
                    Source = ex.ErrorSource
                };

                var json = JsonSerializer.Serialize(error);

                await context.Response.WriteAsync(json);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                var error = new ErrorDetails
                {
                    StatusCode = 500,
                    Message = "Error interno del servidor",
                    Source = ex.Source ?? "Unknown"
                };

                var json = JsonSerializer.Serialize(error);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
