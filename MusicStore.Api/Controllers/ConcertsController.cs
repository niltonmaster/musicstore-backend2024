using Microsoft.AspNetCore.Mvc;
using MusicStore.Dto.Request;
using MusicStore.Dto.Response;
using MusicStore.Entities;
using MusicStore.Repositories;
using MusicStore.Services.Interface;

namespace MusicStore.Api.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class ConcertsController : ControllerBase
    {
        private readonly IConcertService service;

        public ConcertsController(IConcertService service) {
            this.service = service;
        }

        /*[HttpGet]
        public async Task<IActionResult> Get() {

            //return Ok(await concertRepository.GetAsync());

            var response = new BaseResponseGeneric<ICollection<ConcertResponseDto>>();


            try
            {
                //mapear
                var concertsDb =await  concertRepository.GetAsync();
                //var genresDb= genreRepository.GetAsync();
                var concertsDto = concertsDb.Select(x => new ConcertResponseDto {
                    Id = x.Id,
                    Title=x.Title,
                    Description=x.Description,
                    Place=x.Place,
                    UnitPrice   = x.UnitPrice,
                    GenreId=x.GenreId,
                    DateEvent=x.DateEvent,
                    ImageUrl=x.ImageUrl,
                    TicketsQuantity=x.TicketsQuantity,
                    Finalized=x.Finalized,
                    Status=x.Status,
                }).ToList();

                response.Data = concertsDto;//(ICollection<Concert>?)
                response.Success = true;
                //
                logger.LogInformation("Obtenieneod todos los conciertos");
                return Ok(response);



            }
            catch (Exception ex)
            {

                //response.Data = (ICollection<Concert>?)concertsDto;
                response.ErrorMessage   = "Ocurrió un error al obtener los conciertos";
                //response.Success = true;
                logger.LogError(ex, $" {ex.Message} {response.ErrorMessage}");
                return BadRequest(response);
                ;
            }
        }*/

        [HttpGet("title")]
        public async Task<IActionResult> Get(string? title)//string? por si el usuario no envia nada
        {
            
            var response=await service.GetAsync(title);
            return response.Success?Ok(response):  BadRequest(response);
            /*
            var response = new BaseResponseGeneric<ICollection<ConcertResponseDto>>();



            try
            {
                //mapear
                var concertsDb = await concertRepository.GetAsync(x=>x.Title.Contains(title??string.Empty),// podria ir mas como && x.Year>...)
                    x=>x.DateEvent);


                //var genresDb= genreRepository.GetAsync();
                var concertsDto = concertsDb.Select(x => new ConcertResponseDto
                {
                    Id=x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Place = x.Place,
                    UnitPrice = x.UnitPrice,
                    GenreId = x.GenreId,
                    DateEvent = x.DateEvent,
                    ImageUrl = x.ImageUrl,
                    TicketsQuantity = x.TicketsQuantity,
                    Finalized = x.Finalized,
                    Status = x.Status,
                }).ToList();

                response.Data = (ICollection<ConcertResponseDto>?)concertsDto;
                response.Success = true;
                //
                logger.LogInformation($"Obtenieneod todos los conciertos con titulo {title}");
                return Ok(response);



            }
            catch (Exception ex)
            {

                //response.Data = (ICollection<Concert>?)concertsDto;
                response.ErrorMessage = "Ocurrió un error al obtener los conciertos";
                //response.Success = true;
                logger.LogError(ex, $" {ex.Message} {response.ErrorMessage}");
                return BadRequest(response);
                ;
            }*/
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)//string? por si el usuario no envia nada
        {

            var response = await service.GetAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);



        }



        [HttpPost]
        public async Task<IActionResult> Post(ConcertRequestDto concertRequestDto) {


            var response = await service.AddAsync(concertRequestDto);
            return response.Success ? Ok(response) : BadRequest(response);


            //var response = new BaseResponseGeneric<int>();

            /*try
            {
                //validar genreId
                var genre = await service.GetAsync(concertRequestDto.GenreId);
                
                if (genre is null)
                {
                    response.ErrorMessage = $"No existe el genero con id {concertRequestDto.GenreId} por tanto no se puede guardar el concierto";
                    logger.LogWarning(response.ErrorMessage);
                    return BadRequest(response);

                }
                //else { 

                //}


                //var genresDb= genreRepository.GetAsync();
                var concertDb = new Concert //concertsDb.Select(x => new ConcertResponseDto
                {
                    Title = concertRequestDto.Title,
                    Description = concertRequestDto.Description,
                    Place = concertRequestDto.Place,
                    UnitPrice = concertRequestDto.UnitPrice,
                    GenreId = concertRequestDto.GenreId,
                    DateEvent = concertRequestDto.DateEvent,
                    ImageUrl = concertRequestDto.ImageUrl,
                    TicketsQuantity = concertRequestDto.TicketsQuantity,
                    //Finalized = concertRequestDto.Finalized,
                    //Status = concertRequestDto.Status,
                };


                response.Data = await concertRepository.AddAsync(concertDb);
                response.Success = true;
                //
                logger.LogInformation($"Se guardo el concierto con Id {concertDb.Id}");
                return Ok(response);




            }
            catch (Exception ex)
            {

                //response.Data = (ICollection<Concert>?)concertsDto;
                response.ErrorMessage = "Ocurrió un error al guardar el concierto";
                //response.Success = true;
                logger.LogError(ex, $" {ex.Message} {response.ErrorMessage}");
                return BadRequest(response);
                ;
            }
            */
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, ConcertRequestDto concertRequestDto)
        {


            var response = await service.UpdateAsync(id,concertRequestDto);
            return response.Success ? Ok(response) : BadRequest(response);

        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await service.DeleteAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);

        }

        [HttpPatch("{id:int}")]
        public async Task<IActionResult> Patch(int id)
        {
            var response = await service.FinalizeAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);




        }
    }
    }
