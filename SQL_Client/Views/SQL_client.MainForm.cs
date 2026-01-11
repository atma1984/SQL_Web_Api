using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SQL_Client.Views;

namespace SQL_Client
{
    public partial class MainForm : Form, IMainView
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public string ConnectionString => connectionStringTextBox.Text;

        public string StatusMessage
        {
            set { statusLabel.Text = value; }
        }

        public event EventHandler ConnectRequested;
        public event EventHandler GetVersionRequested;
        public event EventHandler DisconnectRequested;

        private void connectButton_Click(object sender, EventArgs e)
        {
            ConnectRequested?.Invoke(this, EventArgs.Empty);
        }

        private void getVersionButton_Click(object sender, EventArgs e)
        {
            GetVersionRequested?.Invoke(this, EventArgs.Empty);
        }

        private void disconnectButton_Click(object sender, EventArgs e)
        {
            DisconnectRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
