using System;
using System.Data.SqlClient;

namespace SQL_Web_Api.Services
{
    public class SqlServerDatabaseService : IDatabaseService
    {
        private readonly ILoggerService _logger;
        private SqlConnection _connection;

        public SqlServerDatabaseService(ILoggerService logger)
        {
            _logger = logger;
        }
        public bool Connect(string connectionString)
        {
            try
            {
                _logger.LogInfo("Попытка подключения к базе данных...");

                _connection = new SqlConnection(connectionString);
                _connection.Open();

                _logger.LogInfo("Успешное подключение к базе данных.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Ошибка при подключении к базе данных. "+ex.Message);
                return false;
            }
        }

        public bool Disconnect()
        {
            try
            {
                if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                    _connection = null;
                    _logger.LogInfo("Соединение с базой данных закрыто.");
                    return true;
                }
                else
                {
                    _logger.LogWarning("Попытка закрытия соединения с уже закрытой или неинициализированной базой данных.");
                    return false;
                }
               
            }
            catch (Exception ex)
            {
                _logger.LogError("Ошибка при разрыве соединения с базой данных."+ex.Message);
                return false;
            }
        }

        public string GetVersion()
        {
            try
            {
                if (_connection == null || _connection.State != System.Data.ConnectionState.Open)
                {
                    _logger.LogWarning("Нет активного соединения с базой данных.");
                    throw new InvalidOperationException("Нет активного соединения с базой данных.");
                }

                using (var cmd = new SqlCommand("SELECT @@VERSION", _connection))
                {
                    var version = cmd.ExecuteScalar().ToString();
                    _logger.LogInfo($"Получена версия Microsoft SQL Server");
                    return version;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Ошибка при получении версии базы данных." + ex.Message);
                return "Ошибка при получении версии базы данных.";
            }
        }
    }
}