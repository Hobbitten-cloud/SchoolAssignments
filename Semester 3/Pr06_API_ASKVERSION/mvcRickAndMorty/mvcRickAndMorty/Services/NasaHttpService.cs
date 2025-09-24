using System.Text.Json;

namespace mvcRickAndMorty.Services
{
    public class NasaHttpService
    {
        public async Task<List<string>> GetDailyImage(HttpClient cli, string endpoint)
        {
            try
            {
                var response = await cli.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();

                var options = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                };

                string json = await response.Content.ReadAsStringAsync();

                if (json.StartsWith("["))
                {
                    var nasaImages = JsonSerializer.Deserialize<List<NasaImageResponse>>(json, options);
                    var imageUrls = new List<string>();

                    foreach (var nasaImage in nasaImages)
                    {
                        if (nasaImage?.Url != null)
                        {
                            Uri baseUri = new Uri("https://api.nasa.gov");
                            Uri fullUrl = new Uri(baseUri, nasaImage.Url);
                            imageUrls.Add(fullUrl.AbsoluteUri);
                        }
                    }

                    return imageUrls;  
                }
                else
                {
                  
                    var nasaImage = JsonSerializer.Deserialize<NasaImageResponse>(json, options);

                    if (nasaImage?.Url != null)
                    {
                        Uri baseUri = new Uri("https://api.nasa.gov");
                        Uri fullUrl = new Uri(baseUri, nasaImage.Url);
                        return new List<string> { fullUrl.AbsoluteUri }; 
                    }
                }

                return new List<string> { "No image found" };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<string> { "Error fetching image" };
            }
        }
    }

    public class NasaImageResponse
    {
        public string Url { get; set; }
        public string Explanation { get; set; }
        public string Title { get; set; }
    }
}
