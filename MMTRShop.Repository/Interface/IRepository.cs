using MMTRShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MMTRShop.Repository.Interface
{
    public interface IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey> where TKey : struct
    {
        TEntity GetById(Guid id); 
        Task<TEntity> GetByIdAsync(Guid id);
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddAsync(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        void Save();
        void SaveAsync();
    }
}
