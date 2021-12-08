using Microsoft.Extensions.Logging;

namespace Points.Logger
{
    public class PointsLogger<TCategoryName> : ILogger<TCategoryName>
    {
        public IDisposable? BeginScope<TState>(TState state) => state as IDisposable;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {

        }
    }
}