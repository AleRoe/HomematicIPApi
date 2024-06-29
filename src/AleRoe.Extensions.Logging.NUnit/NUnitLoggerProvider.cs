using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace AleRoe.Extensions.Logging.NUnit
{
    [ProviderAlias("NUnit")]
    public class NUnitLoggerProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, NUnitLogger> loggers = new();
        public ILogger CreateLogger(string categoryName)
        {
            return loggers.GetOrAdd(categoryName, new NUnitLogger(categoryName));
        }

        public void Dispose()
        {
            loggers.Clear();
        }
    }
}
