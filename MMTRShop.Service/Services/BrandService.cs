using AutoMapper;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.Exceptions;
using MMTRShop.Repository.Entities;
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
        private readonly IMapper _mapper;
        public BrandService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddBrand(BrandDTO brandDTO)
        {
            var brand = _mapper.Map<Brand>(brandDTO);
            await _unitOfWork.Brands.AddAsync(brand);
            await Save();
        }

        public async Task<IEnumerable<BrandDTO>> GetBrands()
        {
            var brands = await _unitOfWork.Brands.GetAllAsync();
            var result = _mapper.Map<IEnumerable<BrandDTO>>(brands);
            return result;
        }
        public async Task<BrandDTO> GetBrand(Guid brandId)
        {
            var brand = await GetBrand(brandId);
            var result = _mapper.Map<BrandDTO>(brand);
            return result;
        }

        public async Task RemoveBrand(Guid brandId)
        {
            var brand = await _unitOfWork.Brands.FindAsync(b => b.Id == brandId);
            if (brand == null)
            {
                throw new NotFoundException("Бренд не найден");
            }
            _unitOfWork.Brands.Remove(brand);
            await Save();
        }

        public async Task Save()
        {
            await _unitOfWork.Brands.SaveAsync();
        }

        public async Task Update(BrandDTO brandDTO)
        {
            var brand = _mapper.Map<Brand>(brandDTO);
            _unitOfWork.Brands.Update(brand);
            await Save();
        }
    }
}
