using MusicStore.Dto.Request;
using MusicStore.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Services.Interface
{
    public interface IConcertService
    {
        Task<BaseResponseGeneric<ICollection<ConcertResponseDto>>> GetAsync(string? title);
        Task<BaseResponseGeneric<ConcertResponseDto>> GetAsync(int id);
        Task<BaseResponseGeneric<int>> AddAsync(ConcertRequestDto entity);
        Task<BaseResponse> UpdateAsync(int id, ConcertRequestDto request);//    (int id, GenreRequestDto genreRequestDto);
        Task<BaseResponse> DeleteAsync(int id);

        Task<BaseResponse> FinalizeAsync(int id);//update especifico 
    }
}
