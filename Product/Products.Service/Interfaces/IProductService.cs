using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;

namespace Products.Service.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> GetProduct(Guid id);

        Task AddProduct(ProductDTO product);
        Task RemoveProduct(Guid productId);
        Task Update(ProductDTO product);
        Task Save();

        Task<IEnumerable<ProductDTO>> GetPageProducts(ProductPageFilter filter);

    }
}
