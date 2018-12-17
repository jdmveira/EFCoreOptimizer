using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace EFCoreOptimizer.Logger
{
    public sealed class CustomLoggerProvider : ILoggerProvider
    {
        private readonly List<string> _logs;

        public CustomLoggerProvider(List<string> logs)
        {
            _logs = logs;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new CustomLogger(_logs);
        }

        public void Dispose()
        {
            // left empty
        }
    }
}
