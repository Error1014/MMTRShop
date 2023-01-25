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
        private readonly UnitOfWork _unitOfWork;
        public BrandService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Brand> GetAllBrand()
        {
            return _unitOfWork.Brands.GetAll().ToList();
        }
        public Brand GetBrand(Product product)
        {
            return _unitOfWork.Brands.Find(b=>b.Id==product.BrandId);
        }
    }
}
