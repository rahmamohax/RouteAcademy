using E_Commerce.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Web.CustomMiddlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
                await HandleNotFoundEndPointAsync(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Somthing Went Wrong");

                //Return custom error problem
                var problem = new ProblemDetails()
                {
                    Title= "Error While Processing Http Request",
                    Detail = ex.Message,
                    Instance = httpContext.Request.Path,
                    Status = ex switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        _ => StatusCodes.Status500InternalServerError
                    }
                };
                httpContext.Response.StatusCode = problem.Status.Value;

                await httpContext.Response.WriteAsJsonAsync(problem);
            }
        }

        private static async Task HandleNotFoundEndPointAsync(HttpContext httpContext)
        {
            if (httpContext.Response.StatusCode == StatusCodes.Status404NotFound && !httpContext.Response.HasStarted)
            {
                var response = new ProblemDetails()
                {
                    Title = "Error While Processing Http Request - EndPoint Not Found",
                    Detail = $"Endpoint {httpContext.Request.Path} Not Found",
                    Status = StatusCodes.Status404NotFound,
                    Instance = httpContext.Request.Path
                };
                await httpContext.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
