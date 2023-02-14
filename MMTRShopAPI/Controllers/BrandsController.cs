using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMTRShop.DTO.DTO;
using MMTRShop.Model.HelperModels;
using MMTRShop.Model.Models;
using MMTRShop.Service.Interface;

namespace MMTRShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : Controller
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
            _brandService.AddBrand(brandDTO);
            return Ok(brandDTO);
        }

        [HttpPut]
        public async Task<IActionResult> Put(BrandDTO brandDTO)
        {
            _brandService.Update(brandDTO);
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
