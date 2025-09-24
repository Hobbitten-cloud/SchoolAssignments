using Pr06_API.Models;
using System.Text.Json;
using System.Net.Http.Json;

namespace Pr06_API.Services
{
    public class RickAndMortyHttpService : IRickAndMortyHttpService
    {
        private IHttpClientFactory _httpClientFactory;

        public RickAndMortyHttpService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Character> GetCharacaterByIdAsync(int id)
        {
            using var httpClient = _httpClientFactory.CreateClient("RickAndMortyJSON");

            var response = await httpClient.GetAsync($"character/{id}");

            //if (!response.IsSuccessStatusCode)
            //{
            //    return null;
            //}

            return await response.Content.ReadFromJsonAsync<Character>();
        }
    }
}
