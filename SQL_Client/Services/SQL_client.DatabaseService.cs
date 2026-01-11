using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Client.Services
{
    internal class DatabaseService
    {

        private readonly HttpClient _httpClient;

        public DatabaseService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5000/") }; // Укажите ваш сервер
        }

        public async Task<string> ConnectAsync(string connectionString)
        {
            var content = new StringContent($"\"{connectionString}\"", Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/database/connect", content);

            if (response.IsSuccessStatusCode)
            {
                return "Connection established successfully.";
            }
            else
            {
                return "Failed to connect.";
            }
        }

        public async Task<string> GetVersionAsync()
        {
            var response = await _httpClient.GetAsync("api/database/version");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return "Failed to get version.";
            }
        }


        public async Task<string> DisconnectAsync()
        {
            var response = await _httpClient.PostAsync("api/database/disconnect", null);

            if (response.IsSuccessStatusCode)
            {
                return "Connection closed successfully.";
            }
            else
            {
                return "Failed to disconnect.";
            }
        }
    }
}
