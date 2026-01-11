using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Client.Services
{
    internal class DatabaseService
    {
        private HttpClient _httpClient;

        public async Task<string> ConnectAsync(string connectionString, string host)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(host) };
            var content = new StringContent($"\"{connectionString}\"", Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/database/connect", content);
       
            if (response.IsSuccessStatusCode)
            {
                var connectData = await response.Content.ReadAsStringAsync();
                return connectData;
            }
            else
            {
                var connectData = await response.Content.ReadAsStringAsync();
                return connectData;
                //return "Failed to connect.";
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
                return await response.Content.ReadAsStringAsync();
                //return "Failed to get version.";
            }
        }


        public async Task<string> DisconnectAsync()
        {
            var response = await _httpClient.PostAsync("api/database/disconnect", null);

            if (response.IsSuccessStatusCode)
            {
                var connectData = await response.Content.ReadAsStringAsync();
                return connectData;
            }
            else
            {
                var connectData = await response.Content.ReadAsStringAsync();
                return connectData;
                //return "Failed to disconnect.";
            }
        }
    }
}
