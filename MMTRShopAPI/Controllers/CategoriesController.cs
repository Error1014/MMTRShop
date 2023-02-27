using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;
using MMTRShop.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace MMTRShopAPI.Controllers
{

    public class CategoriesController : BaseApiController
    {
        private readonly ICategoryServise _categoryService;
        public CategoriesController(ICategoryServise categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> GetCategories([FromQuery]BaseFilter filter)
        {
            var brand = await _categoryService.GetPageCategories(filter);
            if (brand==null)
            {
                throw new NullReferenceException();
            }
            return brand;
        }
        [HttpGet("{id}")]
        public async Task<CategoryDTO> GetBrand(Guid id)
        {
            var brand = await _categoryService.GetCategory(id);
            return brand;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> PostBrands(CategoryDTO brandDTO)
        {
            await _categoryService.AddCategory(brandDTO);
            return Ok(brandDTO);
        }
        [Authorize(Roles = "Admin, Operator")]
        [HttpPut]
        public async Task<IActionResult> Put(CategoryDTO brandDTO)
        {
            await _categoryService.Update(brandDTO);
            return Ok(brandDTO);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _categoryService.Remove(id);
            return Ok($"Категория с id={id} успешно удалена");
        }
    }
}
