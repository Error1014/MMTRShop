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
        public static Brand GetBrandProduct(Product product)
        {
            return UnitOfWork.Brands.Find(b=>b.Id==product.BrandId);
        }
    }
}
