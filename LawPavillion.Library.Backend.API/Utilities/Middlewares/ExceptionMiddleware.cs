using System.Net;
using System.Text.Json;

using LawPavillion.Library.Backend.API.Utilities.Exceptions;

namespace LawPavillion.Library.Backend.API.Utilities.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        // Constructor to inject the next middleware in the pipeline
        public ExceptionMiddleware(RequestDelegate next) => _next = next;

        /// <summary>
        /// Captures and handles exceptions that occur during the request pipeline.
        /// Converts them into standardized JSON responses with appropriate status codes.
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ex switch
                {
                    BadRequestException => (int)HttpStatusCode.BadRequest,
                    NotFoundException => (int)HttpStatusCode.NotFound,
                    AuthenticationException => (int)HttpStatusCode.Unauthorized,
                    _ => (int)HttpStatusCode.InternalServerError
                };

                var response = new { message = ex.Message };
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}
