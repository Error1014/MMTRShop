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
        private readonly IMapper _mapper;
        public BrandsController(IMapper mapper, IBrandService brandService)
        {
            _mapper = mapper;
            _brandService = brandService;
        }


        [HttpGet]
        public async Task<IEnumerable<BrandDTO>> GetBrands()
        {
            var brand = await _brandService.GetBrands();
            var result = _mapper.Map<IEnumerable<BrandDTO>>(brand);
            return result;
        }
        [HttpGet("{id}")]
        public async Task<BrandDTO> GetBrand(Guid id)
        {
            var brand = await _brandService.GetBrand(id);
            var result = _mapper.Map<BrandDTO>(brand);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> PostBrands(BrandDTO brandDTO)
        {
            var brand = _mapper.Map<Brand>(brandDTO);
            _brandService.AddBrand(brand);
            return Ok(brand);
        }

        [HttpPut]
        public async Task<IActionResult> Put(BrandDTO brandDTO)
        {
            var brand = _mapper.Map<Brand>(brandDTO);
            _brandService.Update(brand);
            return Ok(brand);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            Brand brand = await _brandService.GetBrand(id);
            _brandService.RemoveBrand(brand);
            return Ok(brand);
        }
    }
}
