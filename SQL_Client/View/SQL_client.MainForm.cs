using System;
using System.Windows.Forms;
using SQL_Client.Presenters;

namespace SQL_Client
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            new MainPresenter(this);
        }

        public event EventHandler ConnectRequested;
        public event EventHandler GetVersionRequested;
        public event EventHandler DisconnectRequested;


        private void connectButton_Click(object sender, EventArgs e)
        {
            ConnectRequested?.Invoke(sender, e);
        }

        private void getVersionButton_Click(object sender, EventArgs e)
        {
            GetVersionRequested?.Invoke(sender, e);
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            DisconnectRequested?.Invoke(sender, e);
        }

  
    }
}
