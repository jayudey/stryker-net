using Serilog.Events;

namespace Stryker.Core.Logging
{
    public class LogOptions
    {
        public bool LogToFile { get; init; }
        public LogEventLevel LogLevel { get; init; }
    }
}
