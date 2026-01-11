using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Client.Models
{
    internal interface IDatabaseConnection
    {
        Task ConnectAsync(string connectionString);  // Подключение к базе данных
        Task<string> GetVersionAsync();               // Получение версии базы данных
        Task DisconnectAsync();                       // Закрытие подключения
    }
}
