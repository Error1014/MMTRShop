using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service.Services
{
    public class BrandService
    {
        private readonly UnitOfWork UnitOfWork;
        public BrandService()
        {
            UnitOfWork = new UnitOfWork(new ShopContext());
        }
        public List<Brand> GetAllBrand()
        {
            return UnitOfWork.Brands.GetAll().ToList();
        }
        public Brand GetBrand(Product product)
        {
            return UnitOfWork.Brands.Find(b=>b.Id==product.BrandId);
        }
    }
}
