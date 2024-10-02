using Microsoft.AspNetCore.Mvc;
using MusicStore.Dto.Request;
using MusicStore.Dto.Response;
using MusicStore.Entities;
using MusicStore.Repositories;
using MusicStore.Services.Interface;
using System.Net;

namespace MusicStore.Api.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]  ó
    [Route("api/genres")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService service;

        //GenreRepository repository = new GenreRepository();//fuertemente y cambiamos por CDI

        //Ctor inicial sin interfaces:
        public GenresController(IGenreService service)//(IGenreRepository genreRepository, ILogger<GenresController> logger)
        {
            this.service = service;
        }

        //api/genres
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //1° forma
            //var data = genreRepository.Get();


            /* //2° forma
            var data = await genreRepository.GetAsync();
            return Ok(data);*/

            //3° utilizando response DTO
            /*var response = new BaseResponseGeneric<List<GenreResponseDto>>();

            try
            {





                //1°Esto ser areemplazado a cauda del patrno repo
                //response.Data = await genreRepository.GetAsync();

                //2°utilizando patron repo , el mapeo pasa al controlador momentaneamente
                var genreList = await genreRepository.GetAsync();
                var genresResponseDto = genreList.Select(x => new GenreResponseDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Status = x.Status
                }).ToList();

                response.Data = genresResponseDto;// await genreRepository.GetAsync();
                response.Success = true;

                logger.LogInformation("Obteniendo todos los generos musicales...");
                return Ok(response);*
            }
            catch (Exception ex)
            {
                response.ErrorMessage = "Error a obtener datos";
                logger.LogError(ex, $"{response.ErrorMessage} {ex.Message}");

                return BadRequest(response);
            }*/


            //usnado CAPA DE SERVICIO
            var response = await service.GetAsync();
            return response.Success ?
                Ok(response) : BadRequest(response);


        }

        //api/genres/1
        [HttpGet("${id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            //var item= genreRepository.Get(id);

            //2da forma
            /*          var item = await genreRepository.GetAsync(id);
                      return item is not null ? Ok(item) : NotFound();
          */

            //3era
            /*var response = new BaseResponseGeneric<GenreResponseDto>();

             try
             {
                 var genreDb=await genreRepository.GetAsync(id);
                 if (genreDb == null) {
                     logger.LogWarning($"No se encontro gener con id {id}");
                     return NotFound(response);
                 }
                 else
                 {
                     var genre = new GenreResponseDto
                     {
                         Id = genreDb.Id,
                         Name = genreDb.Name,
                         Status = genreDb.Status
                     };

                     response.Data = genre;// await genreRepository.GetAsync(id);
                     response.Success = true;
                     logger.LogInformation($"Obteniendo el genero musical id{id}");

                 }





                 //return response.Data is not null ? Ok(response) : NotFound();
                 return  Ok(response)  ;

             }
             catch (Exception ex )
             {
                 response.ErrorMessage = $"Error al obtener id {id}";
                 logger.LogError(ex, $"{response.ErrorMessage} {ex.Message}");

                 return BadRequest(response);

             }*/

            //4 usando CAPA SERVICOI
            var response = await service.GetAsync(id);
            return response.Success ?
                Ok(response) : BadRequest(response);
        }



        [HttpPost]
        public async Task<IActionResult> Post(GenreRequestDto genre)//(Genre genre)
        {
            //genreRepository.Add(item);


            //2da forma
            /*await genreRepository.AddAsync(item);
            //return Ok(item);
            */


            //3era forma
            /*var response = new BaseResponseGeneric<int>();

            try
            {
                var genreDb = new Genre
                {
                    Name=genre.Name,
                    Status = genre.Status
                };
                 var xxxx= await genreRepository.AddAsync(genreDb);



                response.Data = xxxx;//xxxx.Id; 
                response.Success = true;
                logger.LogInformation($"Insertado el genero musical id {xxxx}");

                //return response.Data is not null ? Ok(response) : NotFound();
                return StatusCode((int) HttpStatusCode.Created, response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = $"Error al obtener al insertar genero";
                logger.LogError(ex, $"{response.ErrorMessage} {ex.Message}");

                return BadRequest(response);
            
            }*/


            //4 usando CAPA SERVICOI
            var response = await service.AddAsync(genre);
            return response.Success ?
                Ok(response) : BadRequest(response);
        }

        [HttpPut("${id:int}")]
        public async Task<IActionResult> Put(int id, GenreRequestDto genre)
        {
            /*
            await genreRepository.UpdateAsync(id, genre);
            return Ok()*/


            //3era forma
            /*
            var response = new BaseResponse();

            try
            {
                //await genreRepository.UpdateAsync(id,genre);
                var genreDb=await genreRepository.GetAsync(id);
                if(genreDb is null){
                    logger.LogWarning($"No se encontro gener con id {id}");
                    return NotFound(response);
                }
                else {
                    genreDb.Name = genre.Name;
                    genreDb.Status = genre.Status;
                }

                await genreRepository.UpdateAsync();//????????? supuestamente actualizara por referencia sin pasar nada...

                //response.Data = genre.Id;
                response.Success = true;
                logger.LogInformation($"Se actualizao el genero musical id {id}");

                //return response.Data is not null ? Ok(response) : NotFound();
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = $"Error al actualizar genero";
                logger.LogError(ex, $"{response.ErrorMessage} {ex.Message}");

                return BadRequest(response);

            }*/

            //4 usando CAPA SERVICOI
            var response = await service.UpdateAsync(id, genre);
            return response.Success ?
                Ok(response) : BadRequest(response);

        }

        [HttpDelete("${id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            //3era forma
            /*
        var response = new BaseResponse();
        try
        {
                 //genreRepository.Delete(id);
                //await genreRepository.DeleteAsync(id);
                //return Ok();


            var genreDb = await genreRepository.GetAsync(id);
                if (genreDb is null)
                {
                    logger.LogWarning($"No se encontro gener con id {id}");
                    return NotFound(response);
                }
                //else
                //{
                    //genreDb.Name = genre.Name;
                    //genreDb.Status = genre.Status;

                //}




                    await genreRepository.DeleteAsync(id);
                    //response.Data = genre.Id;
                    response.Success = true;
                    logger.LogInformation($"Se eliminó el genero musical id {id}");

                    //return response.Data is not null ? Ok(response) : NotFound();
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    response.ErrorMessage = $"Error al eliminar genero";
                    logger.LogError(ex, $"{response.ErrorMessage} {ex.Message}");

                    return BadRequest(response);

                }


               

            }*/


            //4 usando CAPA SERVICOI
            var response = await service.DeleteAsync(id);
            return response.Success ?
                Ok(response) : BadRequest(response);


        }
    }
}
