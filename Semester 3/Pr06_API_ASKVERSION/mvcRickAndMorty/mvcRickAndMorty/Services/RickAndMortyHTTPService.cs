using mvcRickAndMorty.Interfaces;
using mvcRickAndMorty.Models;
using System.Text.Json;

public class RickAndMortyHTTPService : IRickAndMortyHttpService
{
    private readonly IHttpClientFactory _httpClientFactory;

    public RickAndMortyHTTPService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<Character> GetCharacterByIdAsync(int id)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("RickAndMortyApi");

            var endpoint = $"character/{id}";
            var characters = await RickDeserializer.GetCharsFromAPI(client, endpoint);

            return characters?.FirstOrDefault();
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public async Task<CharacterListResponse> GetAllCharactersAsync(int page)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("RickAndMortyApi");
            var endpoint = $"character/?page={page}"; 

            var response = await client.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            var charactersPage = JsonSerializer.Deserialize<CharacterListResponse>(json, options);

            return charactersPage ?? new CharacterListResponse();  
        }
        catch (Exception ex)
        {
            return new CharacterListResponse();  
        }
    }

}
