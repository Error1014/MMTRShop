using Microsoft.EntityFrameworkCore;
using MMTRShop.Model.Models;
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
        public void Add(TEntity entity)
        {
            ShopContext.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            ShopContext.Set<TEntity>().AddRange(entities);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return ShopContext.Set<TEntity>().FirstOrDefault(predicate);
        }
        public IEnumerable<TEntity> GetAll()
        {
            return ShopContext.Set<TEntity>().ToList();
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await ShopContext.Set<TEntity>().ToListAsync();
        }

        public TEntity GetById(Guid id)
        {
            return ShopContext.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity entity)
        {
            ShopContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            ShopContext.Set<TEntity>().RemoveRange(entities);
        }
        public void Save()
        {
            ShopContext.SaveChanges();
        }
    }
}
