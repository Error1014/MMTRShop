using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
using MMTRShop.Repository.Contexts;
using MMTRShop.Repository.Interface;
using System.Linq.Expressions;

namespace MMTRShop.Repository.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey> where TKey : struct
    {
        protected readonly ShopContext ShopContext;
        protected IQueryable<TEntity> Set => ShopContext.Set<TEntity>().AsQueryable();
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
        public async Task<IEnumerable<TEntity>> GetPageElements(BaseFilter filter)
        {
            var query = ShopContext.Set<TEntity>().AsQueryable();
            query = query
                .OrderBy(x => x.Id)
                .Skip((filter.NumPage - 1) * filter.SizePage)
                .Take(filter.SizePage);
            return await query.ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await ShopContext.Set<TEntity>().FindAsync(id);
        }
        #endregion
        #region Remove
        public void Remove(TEntity entity)
        {
            ShopContext.Set<TEntity>().AsTracking();
            ShopContext.Set<TEntity>().Remove(entity);
            ShopContext.Set<TEntity>().AsNoTracking();
        }
        public void Remove(TKey key)
        {
            ShopContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
            var entity = ShopContext.Set<TEntity>().Find(key);
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
