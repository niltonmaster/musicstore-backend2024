using AutoMapper;
using Azure.Core;
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
    public class ConcertService : IConcertService
    {
        private readonly IConcertRepository repository;
        private readonly IGenreRepository genreRepository;
        private readonly ILogger<ConcertService> logger;
        private readonly IMapper mapper;

        public ConcertService(IConcertRepository repository,IGenreRepository genreRepository, ILogger<ConcertService> logger, IMapper mapper) {
            this.repository = repository;
            this.genreRepository = genreRepository;
            this.logger = logger;
            this.mapper = mapper;
        }


        public async Task<BaseResponseGeneric<ICollection<ConcertResponseDto>>> GetAsync(string? title)
        {

            var response = new BaseResponseGeneric<ICollection<ConcertResponseDto>>();

            try
            {
                var data = await repository.GetAsync(title);

                //mapper deberia venir clase Entidad y convertir a DTO.
                response.Data= mapper.Map<ICollection<ConcertResponseDto>>(data);
                response.Success = true;
                logger.LogInformation($"Obtenieneod todos los conciertos con titulo {title}");
                //return Ok(response);




            }
            catch (Exception ex)
            {
                //response.Data = (ICollection<Concert>?)concertsDto;
                response.ErrorMessage = "Ocurrió un error al obtener los conciertos";
                //response.Success = true;
                logger.LogError(ex, $" {ex.Message} {response.ErrorMessage}");
                //return BadRequest(response);
            }

            return response;
        }



        public  async Task<BaseResponseGeneric<ConcertResponseDto>> GetAsync(int id)
        {
            var response = new BaseResponseGeneric<ConcertResponseDto>();

            try
            {

                var data = await repository.GetAsync(id);


                if (data is null)
                {
                    response.ErrorMessage = $"No se encontró el concierto con id {id}.";
                    logger.LogWarning(response.ErrorMessage);
                    return response;
                }

                //mapper deberia venir clase Entidad y convertir a DTO.
                response.Data = mapper.Map<ConcertResponseDto>(data);
                response.Success = true;

            }
            catch (Exception ex)
            {
                //response.Data = (ICollection<Concert>?)concertsDto;
                response.ErrorMessage = "Ocurrió un error al obtener los conciertos";
                //response.Success = true;
                logger.LogError(ex, $" {ex.Message} {response.ErrorMessage}");
                //return BadRequest(response);
            }

            return response;

        }

        public async Task<BaseResponseGeneric<int>> AddAsync(ConcertRequestDto entity)
        {
            var response = new BaseResponseGeneric<int>();

            try
            {
                var genreId = await genreRepository.GetAsync(entity.GenreId);
                if (genreId is null)
                {
                    response.ErrorMessage = $"el genero con  id {entity.GenreId} asociado no existe.";
                    logger.LogWarning($"{response.ErrorMessage}");
                    return response;
                }

                //mapper deberia venir clase Entidad y convertir a DTO.
                var data = await repository.AddAsync(mapper.Map<Concert>(entity));

                response.Data = data;
                response.Success = true;
                //logger.LogInformation($"Obtenieneod todos los conciertos con titulo {title}");




            }
            catch (Exception ex)
            {
                //response.Data = (ICollection<Concert>?)concertsDto;
                response.ErrorMessage = "Ocurrió un error al obtener los conciertos";
                //response.Success = true;
                logger.LogError(ex, $" {ex.Message} {response.ErrorMessage}");
                //return BadRequest(response);
            }

            return response;
        }


        public async Task<BaseResponse> UpdateAsync(int id, ConcertRequestDto request)
        {
            var response = new BaseResponse();

            try
            {
                var x = await repository.GetAsync(id);

                if (x is  null) {
                    response.ErrorMessage = $"el concierto con id {id} desconocido.";
                    return response;
                }

                var genreId= await genreRepository.GetAsync(request.GenreId);
                if (genreId is null) {
                    response.ErrorMessage = $"el genero con  id {id} asociado no existe.";
                    return response;
                }

                mapper.Map(request, x);

                await repository.UpdateAsync();//no se envia segn porque ya esta en el contxto "x"

                response.Success = true;
                //logger.LogInformation($"Obtenieneod todos los conciertos con titulo {title}");

            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al obtener los conciertos";
                logger.LogError(ex, $" {ex.Message} {response.ErrorMessage}");
            }

            return response;
        }


        public async Task<BaseResponse> DeleteAsync(int id)
        {
            var response = new BaseResponse();

            try
            {
                var x = await repository.GetAsync(id);

                if (x is  null)
                {
                    response.ErrorMessage = $"el concierto con id {id} desconocido.";
                    return response;
                }


                //await repository.DeleteAsync(id);//no se envia segn porque ya esta en el contxto "x"


                //prueba que si funcinoa:
                //x.Place = "MX mdoificado x";
                //x.Status = true;
                await repository.DeleteAsync(id);

                response.Success = true;
                //logger.LogInformation($"Obtenieneod todos los conciertos con titulo {title}");

            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al obtener los conciertos";
                logger.LogError(ex, $" {ex.Message} {response.ErrorMessage}");
            }

            return response;

        }

        public async Task<BaseResponse> FinalizeAsync(int id)
        {
            var response = new BaseResponse();

            try
            {
                var x = await repository.GetAsync(id);

                if (x is null)
                {
                    response.ErrorMessage = $"el concierto con id {id} desconocido.";
                    return response;
                }



                //mapper.Map(request, x);

                await repository.FinalizeAsync(id);//no se envia segn porque ya esta en el contxto "x"

                response.Success = true;
                //logger.LogInformation($"Obtenieneod todos los conciertos con titulo {title}");

            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Ocurrió un error al obtener los conciertos";
                logger.LogError(ex, $" {ex.Message} {response.ErrorMessage}");
            }

            return response;
        }



       
    }
}
