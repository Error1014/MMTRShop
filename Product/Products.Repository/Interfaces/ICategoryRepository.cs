using Products.Repository.Entities;
using Shop.Infrastructure.Repository;

namespace Products.Repository.Interfaces
{
    public interface ICategoryRepository : IRepository<Category, Guid>
    {

    }
}
