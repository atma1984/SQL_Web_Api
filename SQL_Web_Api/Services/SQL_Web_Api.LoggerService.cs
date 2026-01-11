using log4net;
using SQL_Web_Api.Services;

public class LoggerService : ILoggerService
{
    private static readonly ILog log = LogManager.GetLogger(typeof(SqlServerDatabaseService));

    public void LogInfo(string message)
    {
        log.Info(message);
    }

    public void LogError(string message)
    {
        log.Error(message);
    }

    public void LogWarning(string message)
    {
        log.Warn(message);
    }
}