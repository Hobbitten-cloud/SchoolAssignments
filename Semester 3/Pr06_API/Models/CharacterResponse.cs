using System.Text.Json.Serialization;

namespace Pr06_API.Models
{
    public class CharacterResponse
    {
        [JsonPropertyName("results")]
        public List<Character> characters { get; init; }

        public Info info { get; init; }
    }

    public class Info
    {
        public int count { get; init; }
        public int pages { get; init; }
        public string next { get; init; }
        public string prev { get; init; }
    }
}
