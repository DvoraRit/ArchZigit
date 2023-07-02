using Microsoft.AspNetCore.Http;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZigitHub.Logger.Enrichers
{
    public class LogEnricher : ILogEventEnricher
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public string transactionId;
        public string userIdentifier;

        public LogEnricher() : this(new HttpContextAccessor())
        {
        }

        public LogEnricher(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            //userPhone = _contextAccessor.HttpContext?.User?.Claims.FirstOrDefault()?.Value;
            userIdentifier = _contextAccessor.HttpContext?.Items?["UserIdentifier"]?.ToString();
            transactionId = _contextAccessor.HttpContext?.Items?["TransactionID"]?.ToString();

            if (userIdentifier != null)
            {
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("UserIdentifier", userIdentifier));
            }

            if (transactionId != null)
            {
                logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("Transaction", transactionId));
            }
        }
    }
}
