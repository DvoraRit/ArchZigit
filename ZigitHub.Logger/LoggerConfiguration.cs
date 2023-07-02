using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZigitHub.Logger
{
    public static class LoggerConfiguration
    {
        public static LogEventLevel DefaultLogLevel = LogEventLevel.Debug;
        public static LoggingLevelSwitch LoggingLevelSwitch = new LoggingLevelSwitch(DefaultLogLevel);
        public static ILogger ConfigureLogger(IConfigurationRoot config)
        {
            return new Serilog.LoggerConfiguration().ReadFrom.Configuration(config)
                .WriteTo.Seq("http://localhost:4431")
                .MinimumLevel.ControlledBy(LoggingLevelSwitch)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Error)
                .MinimumLevel.Override("Sentry", LogEventLevel.Fatal)
                .MinimumLevel.Override("Hangfire", LogEventLevel.Fatal)
                .Enrich.FromLogContext()
                .Enrich.WithClientIp()
                .Enrich.WithRequestID().CreateLogger();
        }
    }
}
