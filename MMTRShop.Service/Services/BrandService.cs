using MMTRShop.Model.Models;
using MMTRShop.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Services
{
    public class BrandService
    {
        private readonly UnitOfWork _unitOfWork;
        public BrandService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public  IEnumerable<Brand> GetAllBrand()
        {
            return _unitOfWork.Brands.GetAll();
        }
        public async Task<IEnumerable<Brand>> GetAllBrandAsync()
        {
            return await _unitOfWork.Brands.GetAllAsync();
        }
        public Brand GetBrand(Product product)
        {
            return _unitOfWork.Brands.Find(b=>b.Id==product.BrandId);
        }
    }
}
