using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Web_Api.Services
{
    public interface IDatabaseService
    {
        string Connect(string connectionString);
        string GetVersion();
        string Disconnect();
    }
}
