using Microsoft.EntityFrameworkCore;
using PersonalAccountMicroservice.PersonalAccount.Repository.Entities;
using PersonalAccountMicroservice.PersonalAccount.Repository.Interfaces;
using Shop.Infrastructure.HelperModels;
using System.Linq.Expressions;

namespace PersonalAccountMicroservice.PersonalAccount.Repository.Repositories
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey> where TKey : struct
    {
        protected DbContext context;
        protected IQueryable<TEntity> Set => context.Set<TEntity>().AsQueryable();
        public Repository(DbContext context)
        {
            this.context = context;
        }
        #region Add
        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().AddRange(entities);
        }
        #endregion
        #region Find

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }
        #endregion

        #region Get
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }
        public async Task<IEnumerable<TEntity>> GetPageElements(BaseFilter filter)
        {
            var query = context.Set<TEntity>().AsQueryable().AsNoTracking();
            query = query
                .OrderBy(x => x.UserId)
                .Skip((filter.NumPage - 1) * filter.SizePage)
                .Take(filter.SizePage);
            return await query.ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }
        #endregion
        #region Remove
        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().AsTracking();
            context.Set<TEntity>().Remove(entity);
            context.Set<TEntity>().AsNoTracking();
        }
        public void Remove(TKey key)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
            var entity = context.Set<TEntity>().Find(key);
            context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
        }

        #endregion

        public void Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
        }

        #region Save
        public void Save()
        {
            context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
        #endregion
    }
}
