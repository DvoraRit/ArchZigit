using Serilog.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZigitHub.Logger.Enrichers;

namespace ZigitHub.Logger
{
    public static class LoggerExtensions
    {
        public static Serilog.LoggerConfiguration WithRequestID(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null) throw new ArgumentNullException(nameof(enrichmentConfiguration));
            return enrichmentConfiguration.With<LogEnricher>();
        }

        public static Serilog.LoggerConfiguration WithClientIp(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null)
                throw new ArgumentNullException(nameof(enrichmentConfiguration));

            return enrichmentConfiguration.With<ClientIpEnricher>();
        }
    }
}
