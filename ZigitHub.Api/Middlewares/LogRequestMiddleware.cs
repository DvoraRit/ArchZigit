using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ZigitHub.Api.Middlewares
{
    public class LogRequestMiddleware
    {
        private readonly RequestDelegate _next;

        private const string SOURCE_KEY = "X-header";

        public LogRequestMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var userIdentifier = context?.User?.Claims.FirstOrDefault()?.Value;

            var logMessage = $"{"{@Action}"} {context.Request?.Method}: {context.Request?.Path.Value}{context.Request?.QueryString}";

            if (userIdentifier != null)
            {
                context.Items["UserIdentifier"] = userIdentifier;
            }

            var transactionGuid = Guid.NewGuid().ToString();

            context.Items["TransactionID"] = transactionGuid;

            context.Request.EnableBuffering();

            var reader = new StreamReader(context.Request.Body);

            string body = await reader.ReadToEndAsync();
            if (context.Request?.Path.Value != "/" && context.Request?.Path.Value.Contains("hangfire") == false)
            {
                Log.Information(logMessage, "Api Request", body);
            }

            context.Request.Body.Position = 0L;

            Stream originalBody = context.Response.Body;

            try
            {
                await using var memStream = new MemoryStream();
                context.Response.Body = memStream;

                await this._next(context);

                memStream.Position = 0;
                var responseBody = new StreamReader(memStream).ReadToEnd();

                if (context.Request?.Path.Value != "/" && context.Request?.Path.Value.Contains("hangfire") == false)
                {
                    // Log.Information(logMessage, LogActions.API_RESPONSE, responseBody);

                    Log.ForContext("Response", responseBody)
                        .ForContext("Action", "Api Response")
                        .Information(logMessage);
                }

                memStream.Position = 0;
                await memStream.CopyToAsync(originalBody);
            }
            finally
            {
                context.Response.Body = originalBody;
            }
        }
    }
}
