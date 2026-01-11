using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Client.Presenters
{
    public interface IMainPresenter
    {
        void OnConnectRequested(object sender, EventArgs e);
        void OnGetVersionRequested(object sender, EventArgs e);
        void OnDisconnectRequested(object sender, EventArgs e);
    }
}
