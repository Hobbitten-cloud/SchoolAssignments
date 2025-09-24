using Pr06_API.Models;
using System.Text.Json;

namespace Pr06_API.Services
{
    public class RickAndMortyHttpService : IRickAndMortyHttpService
    {
        private IHttpClientFactory _httpClientFactory;

        public RickAndMortyHttpService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Character>> GetCharacaterByIdAsync(int id)
        {
            using var httpClient = _httpClientFactory.CreateClient("RickAndMortyJSON");

            return await httpClient.GetFromJsonAsync<Character>($"/character/{id}");
        }
    }
}
