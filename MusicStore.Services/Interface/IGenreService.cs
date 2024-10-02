using MusicStore.Dto.Request;
using MusicStore.Dto.Response;
using MusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Services.Interface
{
    public interface IGenreService
    {
        Task<BaseResponseGeneric<ICollection<GenreResponseDto>>> GetAsync();
        //Task<ICollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);//delegados: son busquedas de forma dinamica. Va premitir traer una serie de resultados en base a una condicion.
        //Task<ICollection<TEntity>> GetAsync<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> orderBy);
        Task<BaseResponseGeneric<GenreResponseDto>> GetAsync(int id);
        Task<BaseResponseGeneric<int>> AddAsync(GenreRequestDto genre);
        Task<BaseResponse> UpdateAsync(int id, GenreRequestDto genreRequestDto);
        Task<BaseResponse> DeleteAsync(int id);


    }
}
