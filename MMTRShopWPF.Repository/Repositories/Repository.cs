using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MMTRShopWPF.Repository.Repositories
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
