using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;
using ZigitHub.Api.Handlers;
using ZigitHub.Api.Models;
using ZigitHub.Configurations;

namespace ZigitHub.Api.Middlewares
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionsMiddleware()
        {

        }
        public ExceptionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IOptions<ApiErrorsConfig> config, IHttpContextAccessor contextAccessor, IOptions<GlobalConfigs> globalConfigs, IMemoryCache cache)
        {
            try
            {
                await _next(httpContext);

                // Hanlde default 404 response
                if (httpContext.Response.StatusCode == (int)HttpStatusCode.NotFound)
                {
                    throw new HttpStatusException(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex, config.Value, contextAccessor, globalConfigs, cache);
            }
        }

        #region private

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, ApiErrorsConfig config,
            IHttpContextAccessor contextAccessor, IOptions<GlobalConfigs> globalConfigs, IMemoryCache cache)
        {
            var statusCode = HttpStatusCode.InternalServerError;

            string errorMessage = config?.DefaultErrorMessage;

            try
            {
                if (exception is HttpStatusException)
                {
                    var httpStatusException = exception as HttpStatusException;
                    statusCode = httpStatusException.StatusCode;

                    if (!string.IsNullOrWhiteSpace(httpStatusException.ErrorMessage))
                    {
                        errorMessage = httpStatusException.ErrorMessage;
                    }
                    //else if (config.DefaultErrorMessagesByStatusCode.ContainsKey(((int)statusCode).ToString()))
                    //{
                    //    errorMessage = config.DefaultErrorMessagesByStatusCode[((int)statusCode).ToString()];
                    //}
                }

                Log.Error(exception, exception.Message);

                await EndRequest(context, statusCode, errorMessage);
            }
            catch (Exception ex)
            {

                Log.Error(ex.Message);

                await EndRequest(context, statusCode, errorMessage);
            }
        }

        private async Task EndRequest(HttpContext context, HttpStatusCode statusCode, string errorMessage)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsync(JsonConvert.SerializeObject(ApiResponseHandler.Failure(statusCode, errorMessage)));
        }

        #endregion
    }
}
