using AutoMapper;
using Microsoft.Extensions.Logging;
using MusicStore.Dto.Request;
using MusicStore.Dto.Response;
using MusicStore.Entities;
using MusicStore.Repositories;
using MusicStore.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Services.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository repository;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        public GenreService(IGenreRepository repository,ILogger<GenreService> logger, IMapper mapper)
        {
            this.repository = repository;
            this.logger = logger;
            this.mapper = mapper;
        }


        public async Task<BaseResponseGeneric<ICollection<GenreResponseDto>>> GetAsync()
        {
            var response= new BaseResponseGeneric<ICollection<GenreResponseDto>>();

            try
            {
                var data= await repository.GetAsync();

                //if (data is null) {
                //    response.ErrorMessage = "No se encontró listado";
                //    response
                //}

                var dto = mapper.Map<ICollection<GenreResponseDto>>(data);// (data, GenreResponseDto);

                response.Data = dto;
                response.Success = true;
                logger.LogInformation("Obteneiendo todos los concienrtos");
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al obtener listado";
                logger.LogError($" {ex.Message} {response.ErrorMessage}");

            }

            return response;
        }


        public async Task<BaseResponseGeneric<GenreResponseDto>> GetAsync(int id)
        {
            var response = new BaseResponseGeneric<GenreResponseDto>();

            try
            {
                var data = await repository.GetAsync(id);

                if (data is null)
                {
                    response.ErrorMessage = "No se encontró listado";
                    //response.Data = null;
                    return response;
                }

                var dto = mapper.Map<GenreResponseDto>(data);// (data, GenreResponseDto);

                response.Data = dto;
                response.Success = true;
                logger.LogInformation($"Obteniendo el genero con id {id}");
            }
            catch (Exception ex)
            {
                response.ErrorMessage = $"Ocurrió un error al obtener genero con id {id}";
                logger.LogError($" {ex.Message} {response.ErrorMessage}");

            }

            return response;

        }

        public async Task<BaseResponseGeneric<int>> AddAsync(GenreRequestDto genre)
        {

            var response = new BaseResponseGeneric<int>();
            try
            {

                var genreDb = mapper.Map<Genre>(genre);
                var data = await repository.AddAsync(genreDb);


                response.Data = data;
                response.Success = true;



            }
            catch (Exception ex)
            {
                response.ErrorMessage = $"Ocurrió un error al insertar un genero";
                logger.LogError($" {ex.Message} {response.ErrorMessage}");
            }
            return response;
        }

        public async Task<BaseResponse> DeleteAsync(int id)
        {

            var response = new BaseResponse();

            try
            {
                var genre= await repository.GetAsync(id);
                if (genre is null) {
                    response.ErrorMessage=($"No se encontro genero con id {id}");
                    logger.LogWarning(response.ErrorMessage);
                    return response;
                }

                await repository.DeleteAsync(id);
                response.Success = true;
                logger.LogInformation($"Se elimino genero con id {id}");
            }
            catch (Exception ex)
            {
                response.ErrorMessage = $"Ocurrió un error al eliminar un genero con {id}";
                logger.LogError($" {ex.Message} {response.ErrorMessage}");
            }


            return response;



        }


      

        public async Task<BaseResponse> UpdateAsync(int id,GenreRequestDto request)
        {
            var response= new BaseResponse();

            try
            {
                var genre = await repository.GetAsync(id);
                if (genre is null)
                {
                    response.ErrorMessage = ($"No se encontro genero con id {id}");
                    logger.LogWarning(response.ErrorMessage);
                    return response;
                }

                //var genreDb=mapper.Map<Genre>(request);
                mapper.Map(request, genre);

                await repository.UpdateAsync();
                response.Success = true;
                logger.LogInformation($"Se actualizo genero con id {id}");
            }
            catch (Exception ex)
            {

                response.ErrorMessage = $"Ocurrió un error al eliminar un genero con {id}";
                logger.LogError($" {ex.Message} {response.ErrorMessage}"); 
            }

            return response;

        }
    }
}
