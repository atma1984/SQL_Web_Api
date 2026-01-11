using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SQL_Web_Api.Services
{
    public class SqlServerDatabaseService : IDatabaseService
    {
        private SqlConnection _connection;
        public void Connect(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public void Disconnect()
        {
            _connection?.Close();
            _connection = null;
        }

        public string GetVersion()
        {
            if (_connection == null || _connection.State != System.Data.ConnectionState.Open)
                throw new InvalidOperationException("No active connection");

            using (var cmd = new SqlCommand("SELECT @@VERSION", _connection))
            {
                return cmd.ExecuteScalar().ToString();
            }
        }
    }
}