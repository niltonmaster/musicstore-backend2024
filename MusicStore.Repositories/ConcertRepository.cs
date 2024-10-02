using Microsoft.EntityFrameworkCore;
using MusicStore.Dto.Response;
using MusicStore.Entities;
using MusicStore.Entities.Info;
using MusicStore.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Repositories
{
    public class ConcertRepository : RepositoryBase<Concert>, IConcertRepository
    {
        public ConcertRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)// cambio de DbContext a AApplicationDbContext
        {
        }

        //EJEMPLO COMO SOBREESCRIBRI
        /*
        public override async Task<ICollection<Concert>> GetAsync()
        {
            //eager loading aproach
            return await context.Set<Concert>()
                .Include(x => x.Genre)
                .AsNoTracking().ToListAsync();
        }*/

        //ahora en vez de lo de arriba crear un nuevo metodo
        public async Task<ICollection<ConcertInfo>> GetAsync(string? title)
        {//ConcertInfo

            //eager loading opotimizado
            /*return await context.Set<Concert>()
                .Include(x => x.Genre)
                .Where(x => x.Title.Contains(title??string.Empty)) 
                .AsNoTracking()
                .Select(x=> new ConcertInfo { 
                    Id=x.Id,
                    Title=x.Title,
                    Description =x.Description,
                    Place=x.Place,
                    UnitPrice=x.UnitPrice,
                    GenreId=x.GenreId,
                    GenreName=x.Genre.Name,
                    ImageUrl=x.ImageUrl,
                    DateEvent=x.DateEvent.ToShortDateString(),
                    TimeEvent = x.DateEvent.ToShortTimeString(),

                    TicketsQuantity =    x.TicketsQuantity,
                    Finalized=x.Finalized,
                    Status=x.Status?"Activo": "Inactivo"
                })
                .ToListAsync();*/


            //Lazy Loading approach: NO utilizamos el Include
            return await context.Set<Concert>()
                .Where(x => x.Title.Contains(title ?? string.Empty))
                .IgnoreQueryFilters()//importnate ignora los stauts false de Gnero asociado
                .AsNoTracking()
                .Select(x => new ConcertInfo//ConcertInfo
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Place = x.Place,
                    UnitPrice = x.UnitPrice,
                    GenreId = x.GenreId,
                    GenreName = x.Genre.Name,
                    ImageUrl = x.ImageUrl,
                    DateEvent = x.DateEvent.ToShortDateString(),
                    TimeEvent = x.DateEvent.ToShortTimeString(),

                    TicketsQuantity = x.TicketsQuantity,
                    Finalized = x.Finalized,
                    Status = x.Status ? "Activo" : "Inactivo"
                })
                .ToListAsync();


            //3° raw querys
            /*
            var query = context.Set<Concert>().FromSqlRaw("usp.zzxxxx {0}", title ?? string.Empty);
            return await query.ToListAsync();*/
        }


        public async Task FinalizeAsync(int id ) {
            var entity = await GetAsync(id);
            if (entity is not null) {
                entity.Finalized = true;
                await UpdateAsync();
            }
        }


        public async Task DeleteAsync2(int id)
        {
            // ???????????????
            var item = await GetAsync(id);
            //if (item is Concert)
            //{
            //    _ = (Concert)item;
            //}

            if (item is not null)
            {

                //context.Remove(item);
                item.Status = false; //////nilton ESTO NO ESTA FUNCINOANDO Y NO SE POR QUE ?????
                await UpdateAsync();//await context.SaveChangesAsync();
            }
            //else
            //{
            //    throw new InvalidOperationException($"No se encontro el registro con id {id}");

            //}

        }

       

    }
}
