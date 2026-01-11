using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Client.Views
{
    public interface IMainView
    {
        string ConnectionString { get; }       // Получение строки подключения
        string StatusMessage { set; }          // Установка сообщения статуса

        event EventHandler ConnectRequested;   // Событие для подключения
        event EventHandler GetVersionRequested; // Событие для получения версии базы данных
        event EventHandler DisconnectRequested; // Событие для разрыва соединения
    }
}
