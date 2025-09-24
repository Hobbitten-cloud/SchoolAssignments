using mvcRickAndMorty.Models;
using System.Text.Json;

public static class RickDeserializer
{
    public static async Task<List<Character>> GetCharsFromAPI(HttpClient client, string endpoint)
    {
        try
        {
            var response = await client.GetAsync(endpoint);
            response.EnsureSuccessStatusCode(); 
            var json = await response.Content.ReadAsStringAsync(); 

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,  
            };

            var character = JsonSerializer.Deserialize<Character>(json, options);

            return character != null ? new List<Character> { character } : new List<Character>();
        }
        catch (Exception ex)
        {
            return new List<Character>();
        }
    }
}
