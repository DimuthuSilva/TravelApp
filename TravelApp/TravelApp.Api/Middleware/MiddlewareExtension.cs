using Microsoft.AspNetCore.Builder;

namespace TravelApp.Api.Middleware
{
    public static class MiddlewareExtension
    {
        /// <summary>
        /// Uses the custom exception handler.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
