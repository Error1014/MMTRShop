using MMTRShop.MiddlewareException.Exceptions;
using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Services
{
    public class BrandService: IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        public BrandService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddBrand(Brand brand)
        {
            _unitOfWork.Brands.Add(brand);
            Save();
        }

        public async Task<IEnumerable<Brand>> GetBrands()
        {
            return await _unitOfWork.Brands.GetAllAsync();
        }
        public async Task<Brand> GetBrand(Guid brandId)
        {
            return await _unitOfWork.Brands.FindAsync(b=>b.Id==brandId);
        }

        public async Task RemoveBrand(Brand brand)
        {
            Brand? brandDB = await GetBrand(brand.Id);
            _unitOfWork.Brands.Remove(brandDB);
            Save();
        }

        public async Task Save()
        {
           await _unitOfWork.Brands.SaveAsync();
        }

        public void Update(Brand brand)
        {
            _unitOfWork.Brands.Update(brand);
            Save();
        }
    }
}
