using mvcRickAndMorty.Models;

namespace mvcRickAndMorty.Interfaces
{
    public interface IRickAndMortyHttpService
    {
        Task<Character> GetCharacterByIdAsync(int id);

        Task<CharacterListResponse> GetAllCharactersAsync(int page);

    }

}
