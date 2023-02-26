using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
using MMTRShop.Service.Interface;
using Microsoft.AspNetCore.Authorization;

namespace MMTRShopAPI.Controllers
{   
    public class BrandsController : BaseApiController
    {
        private readonly IBrandService _brandService;
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet]
        public async Task<IEnumerable<BrandDTO>> GetBrands()
        {
            var brand = await _brandService.GetBrands();
            return brand;
        }
        [HttpGet("{id}")]
        public async Task<BrandDTO> GetBrand(Guid id)
        {
            var brand = await _brandService.GetBrand(id);
            return brand;
        }

        [HttpPost]
        public async Task<IActionResult> PostBrands(BrandDTO brandDTO)
        {
            await _brandService.AddBrand(brandDTO);
            return Ok(brandDTO);
        }

        [HttpPut]
        public async Task<IActionResult> Put(BrandDTO brandDTO)
        {
            await _brandService.Update(brandDTO);
            return Ok(brandDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _brandService.RemoveBrand(id);
            return Ok($"Бренд с id={id} успешно удалён");
        }
    }
}
