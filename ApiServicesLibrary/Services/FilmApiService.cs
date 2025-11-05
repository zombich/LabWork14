using DatabaseLibrary.Models;
using System.Net.Http.Json;

namespace ApiServicesLibrary.Services
{
    public class FilmApiService(HttpClient client)
    {

        private readonly HttpClient _client = client;

        public async Task<IEnumerable<Film>?> GetFilmsAsync()
            => await _client.GetFromJsonAsync<List<Film>>("films/");

        public async Task UpdateFilmAsync(Film film)
        {
            var response = await _client.PutAsJsonAsync($"films/{film.FilmId}", film);
            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveFilmAsync(int id)
        {
            var response = await _client.DeleteAsync($"films/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<Film?> AddFilmAsync(Film film)
        {
            var response = await _client.PostAsJsonAsync("films/", film);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Film>();
        }
    }
}
