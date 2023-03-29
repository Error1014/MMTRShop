using Shop.Infrastructure.HelperModels;
using Products.Repository.Entities;
using Shop.Infrastructure.Repository;

namespace Products.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        Task<IEnumerable<Product>> GetProductsPage(ProductPageFilter filter);

    }
}
