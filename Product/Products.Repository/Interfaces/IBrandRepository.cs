using Products.Repository.Entities;
using Shop.Infrastructure.Repository;

namespace Products.Repository.Interfaces
{
    public interface IBrandRepository : IRepository<Brand, Guid>
    {
    }
}
