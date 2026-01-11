
namespace SQL_Web_Api.Services
{
    public interface ILoggerService
    {
        void LogInfo(string message);
        void LogError(string message);
        void LogWarning(string message);
    }
}
