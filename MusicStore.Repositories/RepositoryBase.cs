using Microsoft.EntityFrameworkCore;
using MusicStore.Entities;
using MusicStore.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Repositories
{
    //AL AGREGAR ABSTRACT aumenta la funcionalidad, podemos hacer una metdo VIRTUAL a alguno de sus metdoos y sobreescrcibirlos. 
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity :  EntityBase
    {
        protected readonly DbContext context;//ApplicationDbContext

        protected RepositoryBase(DbContext applicationDbContext) {
            this.context = applicationDbContext;
        }

        public virtual async Task<ICollection<TEntity>> GetAsync()
        {
            return await context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetAsync(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>()
                .Where(predicate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ICollection<TEntity>> GetAsync<TKey>(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate, System.Linq.Expressions.Expression<Func<TEntity, TKey>> orderBy)
        {
            return await context.Set<TEntity>()
                .Where(predicate)
                .OrderBy(orderBy)
                .AsNoTracking()
                .ToListAsync();
        }

        // ???????????????
        public async Task<TEntity?> GetAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);

            // ???????????????

        }



        public async Task<int> AddAsync(TEntity entity)
        {

            await context.Set<TEntity>().AddAsync(entity);
           await  context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteAsync(int id)
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



        public async Task UpdateAsync()
        {

            await context.SaveChangesAsync();
        }
    }
}
