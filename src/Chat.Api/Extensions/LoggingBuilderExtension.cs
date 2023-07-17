using Serilog.Events;
using Serilog;

namespace Chat.Api.Extensions;

public static class LoggingBuilderExtension
{
    public static void AddLog(this ILoggingBuilder logging)
    {
        var logger = new LoggerConfiguration().WriteTo
                    .File("ChatLogFile.txt", LogEventLevel.Error,
                    rollingInterval: RollingInterval.Day)
                    .CreateLogger();

        logging.AddSerilog(logger);
    }
}
