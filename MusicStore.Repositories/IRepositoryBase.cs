using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MusicStore.Entities;
using System.Linq.Expressions;


namespace MusicStore.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        Task<ICollection<TEntity>> GetAsync();
        Task<ICollection<TEntity>> GetAsync(Expression<Func<TEntity,bool>> predicate);//delegados: son busquedas de forma dinamica. Va premitir traer una serie de resultados en base a una condicion.
        Task<ICollection<TEntity>> GetAsync<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> orderBy);
        Task<TEntity?> GetAsync(int id);
        Task<int> AddAsync(TEntity entity);
        Task UpdateAsync();//    (int id, GenreRequestDto genreRequestDto);
        Task DeleteAsync(int id);
    }
}
