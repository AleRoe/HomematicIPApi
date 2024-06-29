using Microsoft.Extensions.Logging;
using NUnit.Framework;

namespace AleRoe.Extensions.Logging.NUnit
{
    public sealed class NUnitLogger : ILogger
    {
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => default!;

        public bool IsEnabled(LogLevel logLevel) => IsNUnitContext() && logLevel != LogLevel.None;

        public string CategoryName { get; private set; }


        public NUnitLogger(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName)) throw new System.ArgumentException("Value cannot be null or empty.", nameof(categoryName));
            CategoryName = categoryName;
        }


        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (!IsEnabled(logLevel)) return;
            if (formatter == null) throw new ArgumentNullException(nameof(formatter));

            var message = formatter(state, exception);
            if (string.IsNullOrEmpty(message)) return;

            message = $"{logLevel}: {message}";

            //if (exception != null)
            //{
            //    message += Environment.NewLine + exception.ToString() + Environment.NewLine;
            //}

            TestContext.Out.WriteLine(message);
        }

        private static bool IsNUnitContext() => TestContext.Out != null;
    }
}
