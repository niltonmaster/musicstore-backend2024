using Microsoft.EntityFrameworkCore;
using MusicStore.Dto.Request;
using MusicStore.Dto.Response;
using MusicStore.Entities;
using MusicStore.Persistence;

namespace MusicStore.Repositories
{
    //public class GenreRepository : IGenreRepository //se reeemplazara con la linea abajo 
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository

    {

        public GenreRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }

        


        #region comento Anterior a utilizar REPOSITORYBASE E IREPOSITORYBASE
        ////private readonly List<Genre> genresList;
        //private readonly ApplicationDbContext context;

        //public GenreRepository(ApplicationDbContext context)
        //{
        //    this.context = context;
        //    /*//en memoria
        //    genresList = new List<Genre>();
        //    genresList.Add(new Genre { Id = 1, Name = "Salsa" });
        //    genresList.Add(new Genre { Id = 2, Name = "Cumbia" });
        //    genresList.Add(new Genre { Id = 3, Name = "Bachata" });*/

        //}

        ////metodos...
        //public async Task<List<GenreResponseDto>> GetAsync()
        //{

        //    //return await context.Genres.ToListAsync();


        //    //2°
        //    //La bd no conoce Dto sino Genre por tanto hay que mapear.
        //    var items = await context.Set<Genre>().ToListAsync();//context.Genres.ToListAsync();

        //    //´Mapping manual
        //    /*List<GenreResponseDto> lista = new();
        //    foreach (var item in items)
        //    {
        //        lista.Add(new GenreResponseDto { 
        //            Id=item.Id,
        //            Name=item.Name,
        //            Status= item.Status
        //        });
        //    }
        //    return lista;*/

        //    //mapping mejorado mas eficiente que mapping manual:
        //    var genresResponseDto = items.Select(x => new GenreResponseDto
        //    {
        //        Id = x.Id,
        //        Name = x.Name,
        //        Status = x.Status
        //    }).ToList();
        //    return genresResponseDto;
        //}


        //public async Task<GenreResponseDto?> GetAsync(int id)
        //{
        //    //return genresList.FirstOrDefault(x => x.Id == id);

        //    var item= await context.Set<Genre>().FirstOrDefaultAsync(x => x.Id == id);//context.Genres...

        //    var genresResponseDto = new GenreResponseDto();

        //    if (item is not null)
        //    {
        //        //return item;

        //        //mapping
        //        //var genresResponseDto = new GenreResponseDto
        //        //{
        //        genresResponseDto.Id = item.Id;
        //            genresResponseDto.Name = item.Name;
        //        genresResponseDto.Status = item.Status;
        //        //};

        //    }

        //    else
        //        throw new InvalidOperationException($"No se encontro el registro con id {id}");
        //        return genresResponseDto;
        //}


        //public async Task<int> AddAsync(GenreRequestDto genreRequestDto)
        //{

        //    var genre = new Genre
        //    {
        //        //Id = genreRequestDto.Id,
        //        Name = genreRequestDto.Name,
        //        Status = genreRequestDto.Status
        //    };

        //    context.Set<Genre>().Add(genre);//context.genres...
        //    context.Add(genre);
        //    await context.SaveChangesAsync();
        //    return genre.Id;
        //}


        //public async Task UpdateAsync(int id, GenreRequestDto genreRequestDto)
        //{
        //    /*var item = Get(id);

        //    //Referencia:
        //    if (item is not null)// != o == operadores se pueden sobreescribir. Por tanto utilizamos IS NULL o IS NOT NULL
        //    {
        //        //item.Id = genre.Id;
        //        item.Name = genre.Name;
        //        item.Status = genre.Status;
        //    }*/


        //    //3° dto
        //    //var item = await GetAsync(id);
        //    var item = await context.Set<Genre>().FirstOrDefaultAsync(x=>x.Id==id);

        //    if (item is not null)
        //    {
        //        //item.Id = genre.Id;
        //        item.Name = genreRequestDto.Name;
        //        item.Status = genreRequestDto.Status;
        //        context.Update(item);//context.Set<Genre>().Update(item);
        //        await context.SaveChangesAsync();
        //    }

        //    else { 
        //        throw new InvalidOperationException($"No se encontro el registro con id {id}");

        //    }


        //}

        //public async Task DeleteAsync(int id)
        //{
        //    //var item = await GetAsync(id);
        //    var item = await context.Set<Genre>().FirstOrDefaultAsync(x => x.Id == id);



        //    //Referencia:
        //    if (item is not null)
        //    {
        //        //var genre = new Genre
        //        //{
        //        //    Id = item.Id,
        //        //    Name = item.Name,
        //        //    Status = item.Status
        //        //};

        //        //context.Set<Genre>().Remove(item);
        //        context.Remove(item);

        //        await context.SaveChangesAsync();
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException($"No se encontro el registro con id {id}");

        //    }
        //}

        #endregion

    }
}
