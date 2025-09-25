using Pr06_API.Models;

namespace Pr06_API.Services
{
    public interface IRickAndMortyHttpService
    {
        Task<Character> GetCharacaterByIdAsync(int id);
        Task<CharacterResponse> GetAllCharacters();
    }
}
