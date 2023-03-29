using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Service.Interfaces;
using Shop.Infrastructure;
using Shop.Infrastructure.Attributes;
using Shop.Infrastructure.DTO;

namespace Products.Api.Controllers
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
        [RoleAuthorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> PostBrands(BrandDTO brandDTO)
        {
            await _brandService.AddBrand(brandDTO);
            return Ok(brandDTO);
        }

        [RoleAuthorize("Admin")]
        [HttpPut]
        public async Task<IActionResult> Put(BrandDTO brandDTO)
        {
            await _brandService.Update(brandDTO);
            return Ok(brandDTO);
        }

        [RoleAuthorize("Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _brandService.RemoveBrand(id);
            return Ok($"Бренд с id={id} успешно удалён");
        }
    }
}
