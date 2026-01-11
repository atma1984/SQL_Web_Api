
namespace SQL_Web_Api.Services
{
    public interface IDatabaseService
    {
        bool Connect(string connectionString);
        string GetVersion();
        bool Disconnect();
    }
}
