using MusicStore.Dto.Request;
using MusicStore.Dto.Response;
using MusicStore.Entities;

namespace MusicStore.Repositories
{
    public interface IGenreRepository : IRepositoryBase<Genre>
    {
        //todo lo debajo ira en IREPOSTORYBASE 
        /*Task<int> AddAsync(GenreRequestDto genre);//(Genre genre);
        Task DeleteAsync(int id);
        Task<List<GenreResponseDto>> GetAsync();
        Task<GenreResponseDto?> GetAsync(int id);
        Task UpdateAsync(int id, GenreRequestDto genre);*/
    }
}