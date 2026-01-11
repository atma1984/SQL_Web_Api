using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQL_Client.Services;
using SQL_Client.Views;

namespace SQL_Client.Presenters
{
    internal class MainPresenter
    {
        private readonly IMainView _view;
        private readonly DatabaseService _databaseService;

        public MainPresenter(IMainView view, DatabaseService databaseService)
        {
            _view = view;
            _databaseService = databaseService;

            // Подписка на события
            _view.ConnectRequested += OnConnectRequested;
            _view.GetVersionRequested += OnGetVersionRequested;
            _view.DisconnectRequested += OnDisconnectRequested;
        }

        public async void OnConnectRequested(object sender, EventArgs e)
        {
            try
            {
                var result = await _databaseService.ConnectAsync(_view.ConnectionString);
                _view.StatusMessage = result;
            }
            catch (Exception ex)
            {
                _view.StatusMessage = $"Error: {ex.Message}";
            }
        }

        public async void OnGetVersionRequested(object sender, EventArgs e)
        {
            try
            {
                var version = await _databaseService.GetVersionAsync();
                _view.StatusMessage = $"Database Version: {version}";
            }
            catch (Exception ex)
            {
                _view.StatusMessage = $"Error: {ex.Message}";
            }
        }

        public async void OnDisconnectRequested(object sender, EventArgs e)
        {
            try
            {
                var result = await _databaseService.DisconnectAsync();
                _view.StatusMessage = result;
            }
            catch (Exception ex)
            {
                _view.StatusMessage = $"Error: {ex.Message}";
            }
        }

    }
}
