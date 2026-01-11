using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Web_Api.Services
{
    public interface IDatabaseService
    {
        void Connect(string connectionString);
        string GetVersion();
        void Disconnect();
    }
}
