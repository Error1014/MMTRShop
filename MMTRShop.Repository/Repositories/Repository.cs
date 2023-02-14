using Microsoft.EntityFrameworkCore;
using MMTRShop.Model.Models;
using MMTRShop.Repository.Contexts;
using MMTRShop.Repository.Interface;
using System.Linq.Expressions;

namespace MMTRShop.Repository.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey> where TKey : struct
    {
        protected readonly ShopContext ShopContext;

        public Repository(ShopContext context)
        {
            ShopContext = context;
        }
        #region Add
        public void Add(TEntity entity)
        {
            ShopContext.Set<TEntity>().Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await ShopContext.Set<TEntity>().AddAsync(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            ShopContext.Set<TEntity>().AddRange(entities);
        }
        #endregion
        #region Find

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await ShopContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }
        #endregion
        #region Get
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await ShopContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await ShopContext.Set<TEntity>().FindAsync(id);
        }
        #endregion
        #region Remove
        public void Remove(TEntity entity)
        {
            ShopContext.Set<TEntity>().Remove(entity);
        }


        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            ShopContext.Set<TEntity>().RemoveRange(entities);
        }

        #endregion

        public void Update(TEntity entity)
        {
            ShopContext.Set<TEntity>().Update(entity);
        }

        #region Save
        public void Save()
        {
            ShopContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await ShopContext.SaveChangesAsync();
        }

        #endregion
    }
}
