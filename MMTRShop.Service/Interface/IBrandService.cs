using MMTRShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Interface
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> GetBrands();
        Task<Brand> GetBrand(Guid brandId);
        void AddBrand(Brand brand);
        Task RemoveBrand(Brand brand);
        void Update(Brand brand);
        Task Save();
    }
}
