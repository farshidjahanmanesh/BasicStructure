using Ardalis.Result;
using Loan.Core.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Loan.Framework.Endpoints.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

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

        private Task ConvertException(HttpContext context, Exception ex)
        {
            var httpStatusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var result = string.Empty;
            Result response = Result.Error();

            switch (ex)
            {
                //case ValidationException vException:
                //    httpStatusCode = HttpStatusCode.BadRequest;
                //    response = Result.Invalid(vException.ValidationErrors.Select(c => new ValidationError()
                //    {
                //        ErrorMessage = c
                //    }).ToList());
                //    break;
                case BadRequestException brException:
                    response = Result.Error(brException.Message);
                    break;
                case RateLimitException rateLimitException:
                    response = Result.Error(rateLimitException.Message);
                    break;
                case Exception eException:
                    response = Result.Error(eException.Message);
                    break;
            }
            context.Response.StatusCode = (int)httpStatusCode;
            result = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(result);
        }
    }
}
