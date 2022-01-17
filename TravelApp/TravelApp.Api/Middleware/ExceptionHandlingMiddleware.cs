using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using TravelApp.Application.Exceptions;

namespace TravelApp.Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionHandlingMiddleware"/> class.
        /// </summary>
        /// <param name="next">The next.</param>
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// Invokes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await ConvertException(context, ex);
            }
        }

        /// <summary>
        /// Converts the exception.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        private Task ConvertException(HttpContext context, Exception exception)
        {
            //set the default status code to return in case nothing matches
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

            //set the response content type
            context.Response.ContentType = "application/json";

            var result = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.ValidationErrors);
                    break;
                case BadRequestException badRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = badRequestException.Message;
                    break;
                case NotFoundException notFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    break;
                case Exception ex:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    break;
            }

            //set response status code
            context.Response.StatusCode = (int)httpStatusCode;

            if (result == string.Empty)
            {
                result = JsonConvert.SerializeObject(new { error = exception.Message });
            }

            //write to the response
            return context.Response.WriteAsync(result);
        }
    }
}
