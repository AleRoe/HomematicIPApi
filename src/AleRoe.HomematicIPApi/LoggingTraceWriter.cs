using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System;
using System.Diagnostics;

namespace AleRoe.HomematicIpApi
{
    internal class LoggingTraceWriter : ITraceWriter
    {
        private readonly ILogger logger;

        public TraceLevel LevelFilter { get; set; }

        public LoggingTraceWriter(ILogger logger) : this(logger, TraceLevel.Error) { }

        public LoggingTraceWriter(ILogger logger, TraceLevel level)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            LevelFilter = level;
        }

        public void Trace(TraceLevel level, string message, Exception ex)
        {
            if (level == TraceLevel.Off) return;
            logger.Log(GetLogLevel(level), ex, message);
        }

        private static LogLevel GetLogLevel(TraceLevel level) => 
            level switch
            {
                TraceLevel.Off => LogLevel.None,
                TraceLevel.Error => LogLevel.Error,
                TraceLevel.Warning => LogLevel.Warning,
                TraceLevel.Info => LogLevel.Information,
                TraceLevel.Verbose => LogLevel.Debug,
                _ => LogLevel.Trace
            };
    }   
}
