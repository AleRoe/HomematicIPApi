using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;

namespace AleRoe.Extensions.Logging.NUnit
{
    public static class LoggerFactoryExtensions
    {
        public static ILoggingBuilder AddNUnit(this ILoggingBuilder builder)
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<ILoggerProvider, NUnitLoggerProvider>());
            return builder;
        }
    }
}
