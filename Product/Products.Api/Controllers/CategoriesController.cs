using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Products.Service.Interfaces;
using Shop.Infrastructure;
using Shop.Infrastructure.Attributes;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;

namespace Products.Api.Controllers
{

    public class CategoriesController : BaseApiController
    {
        private readonly ICategoryServise _categoryService;
        public CategoriesController(ICategoryServise categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> GetCategories([FromQuery] BaseFilter filter)
        {
            var brand = await _categoryService.GetPageCategories(filter);
            if (brand == null)
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
        [RoleAuthorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> PostBrands(CategoryDTO brandDTO)
        {
            await _categoryService.AddCategory(brandDTO);
            return Ok(brandDTO);
        }
        [RoleAuthorize("Admin Operator")]
        [HttpPut]
        public async Task<IActionResult> Put(CategoryDTO brandDTO)
        {
            await _categoryService.Update(brandDTO);
            return Ok(brandDTO);
        }
        [RoleAuthorize("Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _categoryService.Remove(id);
            return Ok($"Категория с id={id} успешно удалена");
        }
    }
}
