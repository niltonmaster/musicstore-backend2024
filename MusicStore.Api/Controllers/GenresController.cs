using Microsoft.AspNetCore.Mvc;
using MusicStore.Entities;
using MusicStore.Repositories;

namespace MusicStore.Api.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]  ó
    [Route("api/genres")]
    public class GenresController: ControllerBase
    {
        private readonly IGenreRepository genreRepository;

        //GenreRepository repository = new GenreRepository();//fuertemente y cambiamos por CDI

        //Ctor inicial sin interfaces:
        public GenresController(IGenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        //api/genres
        [HttpGet]
        public async Task<IActionResult> Get() {
            //var data = genreRepository.Get();
            var data = await genreRepository.GetAsync();
            return Ok(data);
        }

        //api/genres/1
        [HttpGet("${id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            //var item= genreRepository.Get(id);
            var item = await genreRepository.GetAsync(id);
            return item is not null? Ok(item) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post( Genre item)
        {
            //genreRepository.Add(item);

            await genreRepository.AddAsync(item);
            return Ok(item);

        }

        [HttpPut("${id:int}")]
        public async Task<IActionResult> Put(int id, Genre genre) {
            await genreRepository.UpdateAsync(id, genre);
            return Ok();
        }

        [HttpDelete("${id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            //genreRepository.Delete(id);
            await genreRepository.DeleteAsync(id);
            return Ok();
        }



    }
}
