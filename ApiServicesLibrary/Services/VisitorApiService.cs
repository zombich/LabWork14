using DatabaseLibrary.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace ApiServicesLibrary.Services
{
    public class VisitorApiService(HttpClient client, JsonSerializerOptions jsonOptions)
    {

        private readonly HttpClient _client = client;

        private readonly JsonSerializerOptions _jsonOptions = jsonOptions;

        public async Task<IEnumerable<Visitor>?> GetVisitorsAsync()
        {
            var response = await _client.GetAsync("visitors/");
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Visitor>?>(content, _jsonOptions);
        }

        public async Task<Film> GetFilmByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveFilmAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateVisitorAsync(Visitor visitor)
        {
            var json = JsonSerializer.Serialize(visitor, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($"visitors/{visitor.VisitorId}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task<Visitor?> AddVisitorAsync(Visitor visitor)
        {
            var json = JsonSerializer.Serialize(visitor, _jsonOptions);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("visitors/", content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Visitor?>();
        }
    }
}
