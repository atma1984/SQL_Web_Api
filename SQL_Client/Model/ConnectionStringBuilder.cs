using System.Data.SqlClient;

namespace SQL_Client.Model
{
    internal class ConnectionStringBuilder
    {
        public static string BuildSqlConnectionString(string _dataSource, string _initialCatalog,bool _integratedSecurity, string _userID, string _password)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = _dataSource,        
                InitialCatalog = _initialCatalog,  
                IntegratedSecurity = _integratedSecurity,      
                UserID = _userID,            
                Password = _password         
            };

            return builder.ConnectionString;
        }
    }
}
