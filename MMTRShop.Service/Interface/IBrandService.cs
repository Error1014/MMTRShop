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
        Task<IEnumerable<Brand>> GetAllBrand();
        Task<IEnumerable<Brand>> GetAllBrandAsync();
        Task<Brand> GetBrand(Product product);
    }
}
