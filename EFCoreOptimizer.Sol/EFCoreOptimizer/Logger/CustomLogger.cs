using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace EFCoreOptimizer.Logger
{
    public class CustomLogger : ILogger
    {
        private readonly List<string> _logs;

        public CustomLogger(List<string> logs)
        {
            _logs = logs;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= LogLevel.Information;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            _logs.Add(formatter(state, exception));
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}
