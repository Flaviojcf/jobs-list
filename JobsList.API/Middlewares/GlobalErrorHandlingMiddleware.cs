using JobsList.Application.Exceptions;
using JobsList.Domain.Constants;
using JobsList.Domain.Validation;
using System.Net;
using System.Text.Json;

namespace JobsList.API.Middlewares
{
    public class GlobalErrorHandlingMiddleware(RequestDelegate requestDelegate)
    {
        private readonly RequestDelegate _requestDelegate = requestDelegate;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            ErrorValidation errorValidation;

            var exceptionType = ex.GetType();

            if (exceptionType == typeof(NotFoundException))
            {
                errorValidation = new ErrorValidation($"{ex.Message} {ex?.InnerException?.Message}", HttpStatusCode.NotFound);
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else
            {
                errorValidation = new ErrorValidation(MessageConstants.GLOBAL_MESSAGE_FOR_INTERNAL_ERROR_EXCEPTION, HttpStatusCode.InternalServerError);

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            var result = JsonSerializer.Serialize(errorValidation);
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}
