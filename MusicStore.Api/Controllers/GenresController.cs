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
        private readonly GenreRepository genreRepository;

        //GenreRepository repository = new GenreRepository();//fuertemente y cambiamos por CDI

        //Ctor inicial sin interfaces:
        public GenresController(GenreRepository genreRepository)
        {
            this.genreRepository = genreRepository;
        }

        //api/genres
        [HttpGet]
        public ActionResult<List<Genre>> Get(int id) {
            var data = genreRepository.Get();
            return Ok(data);
        }

        //api/genres/1
        [HttpGet("${id:int}")]
        public ActionResult<Genre> GetById(int id)
        {
            var item= genreRepository.Get(id);
            return item is not null? Ok(item) : NotFound();
        }

        [HttpPost]
        public ActionResult Post( Genre item)
        {
            genreRepository.Add(item);
            return Ok(item);

        }

        [HttpPut("${id:int}")]
        public ActionResult Put(int id, Genre genre) {
            genreRepository.Update(id, genre);
            return Ok();
        }

        [HttpDelete("${id:int}")]
        public ActionResult Delete(int id)
        {
            genreRepository.Delete(id);
            return Ok();
        }



    }
}
