using MMTRShopWPF.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service.Services
{
    public class BrandService:BaseService
    {
        public static List<Brand> GetAllBrand()
        {
            return UnitOfWork.Brands.GetAll().ToList();
        }

        public static Brand GetBrandProduct(Guid productId)
        {
            return GetAllBrand().Where(brand => brand.Id == productId).FirstOrDefault();
        }
    }
}
