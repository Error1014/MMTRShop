using Shop.Infrastructure.HelperModels;
using System.Linq.Expressions;
using PersonalAccountMicroservice.PersonalAccount.Repository.Entities;

namespace PersonalAccountMicroservice.PersonalAccount.Repository.Interfaces
{
    public interface IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey> where TKey : struct
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetPageElements(BaseFilter filter);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void Remove(TKey key);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Save();
        Task SaveAsync();
    }
}
