using Microsoft.EntityFrameworkCore;
using MusicStore.Entities;
using MusicStore.Persistence;

namespace MusicStore.Repositories
{
    public class GenreRepository : IGenreRepository
    {

        //private readonly List<Genre> genresList;
        private readonly ApplicationDbContext context;

        public GenreRepository(ApplicationDbContext context)
        {
            this.context = context;
            /*//en memoria
            genresList = new List<Genre>();
            genresList.Add(new Genre { Id = 1, Name = "Salsa" });
            genresList.Add(new Genre { Id = 2, Name = "Cumbia" });
            genresList.Add(new Genre { Id = 3, Name = "Bachata" });*/

        }

        //metodos...
        public async Task<List<Genre>> GetAsync()
        {

            return await context.Genres.ToListAsync();
        }


        public async Task<Genre?> GetAsync(int id)
        {
            //return genresList.FirstOrDefault(x => x.Id == id);

            return await context.Genres.FirstOrDefaultAsync(x => x.Id == id);

        }


        public async Task<int> AddAsync(Genre genre)
        {
            context.Genres.Add(genre);
            context.Add(genre);
            await context.SaveChangesAsync();
            return genre.Id;
        }


        public async Task UpdateAsync(int id, Genre genre)
        {
            /*var item = Get(id);

            //Referencia:
            if (item is not null)// != o == operadores se pueden sobreescribir. Por tanto utilizamos IS NULL o IS NOT NULL
            {
                //item.Id = genre.Id;
                item.Name = genre.Name;
                item.Status = genre.Status;
            }*/

            var item = await GetAsync(id);
            if (item is not null)
            {
                //item.Id = genre.Id;
                item.Name = genre.Name;
                item.Status = genre.Status;
                context.Update(item);
                await context.SaveChangesAsync();
            }


        }

        public async Task DeleteAsync(int id)
        {
            var item = await GetAsync(id);

            //Referencia:
            if (item is not null)
            {
                context.Genres.Remove(item);
                await context.SaveChangesAsync();
            }
        }


    }
}
