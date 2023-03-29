using Shop.Infrastructure.DTO;

namespace Products.Service.Interfaces
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDTO>> GetBrands();
        Task<BrandDTO> GetBrand(Guid brandId);
        Task AddBrand(BrandDTO brand);
        Task RemoveBrand(Guid brand);
        Task Update(BrandDTO brand);
        Task Save();
    }
}
