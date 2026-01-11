using System;
using SQL_Client.Model;
using SQL_Client.Services;


namespace SQL_Client.Presenters
{
    internal class MainPresenter
    {
        private readonly MainForm _view;
        private readonly DatabaseService _databaseService;       

        public MainPresenter(MainForm view)
        {
            _view = view;
            _databaseService = new DatabaseService();
   
            _view.ConnectRequested += OnConnectRequested;
            _view.GetVersionRequested += OnGetVersionRequested;
            _view.DisconnectRequested += OnDisconnectRequested;
        }
        public async void OnConnectRequested(object sender, EventArgs e)
        {
            string connection_string = ConnectionStringBuilder.BuildSqlConnectionString(_view.ServerNameTextBox.Text,
                                                                                        _view.BaseNameTextBox.Text,
                                                                                        false,
                                                                                        _view.UserIdTextBox.Text,
                                                                                        _view.PasswordTextBox.Text);
            try
            {
                var result = await _databaseService.ConnectAsync(connection_string,_view.WebApiHostTextBox.Text);
                _view.statusLabel.Text = result;
            }
            catch (Exception ex)
            {
                _view.statusLabel.Text = $"Error: {ex.Message}";
            }
        }

        public async void OnGetVersionRequested(object sender, EventArgs e)
        {
            try
            {
                var version = await _databaseService.GetVersionAsync();
                _view.statusLabel.Text = $"Database Version: {version}";
            }
            catch (Exception ex)
            {
                _view.statusLabel.Text = $"Error: {ex.Message}";
            }
        }

        public async void OnDisconnectRequested(object sender, EventArgs e)
        {
            try
            {
                var result = await _databaseService.DisconnectAsync();
                _view.statusLabel.Text = result;
            }
            catch (Exception ex)
            {
                _view.statusLabel.Text = $"Error: {ex.Message}";
            }
        }

    }
}
