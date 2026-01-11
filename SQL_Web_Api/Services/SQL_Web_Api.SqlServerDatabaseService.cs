using System;
using System.Data.SqlClient;
using log4net;

namespace SQL_Web_Api.Services
{
    public class SqlServerDatabaseService : IDatabaseService
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(SqlServerDatabaseService));
        private SqlConnection _connection;
        public void Connect(string connectionString)
        {
            //_connection = new SqlConnection(connectionString);
            //_connection.Open();
            try
            {
                log.Info("Попытка подключения к базе данных...");

                _connection = new SqlConnection(connectionString);
                _connection.Open();

                log.Info("Успешное подключение к базе данных.");
            }
            catch (Exception ex)
            {
                log.Error("Ошибка при подключении к базе данных.", ex);
                throw new InvalidOperationException("Не удалось подключиться к базе данных.", ex);
            }
        }

        public void Disconnect()
        {
            //_connection?.Close();
            //_connection = null;
            try
            {
                if (_connection != null && _connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                    log.Info("Соединение с базой данных закрыто.");
                }
                else
                {
                    log.Warn("Попытка закрытия соединения с уже закрытой или неинициализированной базой данных.");
                }
                _connection = null;
            }
            catch (Exception ex)
            {
                log.Error("Ошибка при разрыве соединения с базой данных.", ex);
                throw new InvalidOperationException("Не удалось разорвать соединение с базой данных.", ex);
            }
        }

        public string GetVersion()
        {

            //if (_connection == null || _connection.State != System.Data.ConnectionState.Open)
            //    throw new InvalidOperationException("No active connection");

            //using (var cmd = new SqlCommand("SELECT @@VERSION", _connection))
            //{
            //    return cmd.ExecuteScalar().ToString();
            //}
            try
            {
                if (_connection == null || _connection.State != System.Data.ConnectionState.Open)
                {
                    log.Warn("Нет активного соединения с базой данных.");
                    throw new InvalidOperationException("No active connection");
                }

                using (var cmd = new SqlCommand("SELECT @@VERSION", _connection))
                {
                    var version = cmd.ExecuteScalar().ToString();
                    log.Info($"Получена версия базы данных: {version}");
                    return version;
                }
            }
            catch (Exception ex)
            {
                log.Error("Ошибка при получении версии базы данных.", ex);
                throw new InvalidOperationException("Не удалось получить версию базы данных.", ex);
            }
        }
    }
}