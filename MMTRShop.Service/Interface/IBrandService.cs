using Shop.Infrastructure.DTO;
using MMTRShop.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Interface
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
