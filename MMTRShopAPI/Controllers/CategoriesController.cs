using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMTRShop.DTO.DTO;
using MMTRShop.Model.HelperModels;
using MMTRShop.Service.Interface;

namespace MMTRShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly ICategoryServise _categoryService;
        public CategoriesController(ICategoryServise categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            BaseFilter filter = new BaseFilter(1, 5);
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

        [HttpPost]
        public async Task<IActionResult> PostBrands(CategoryDTO brandDTO)
        {
            await _categoryService.AddCategory(brandDTO);
            return Ok(brandDTO);
        }

        [HttpPut]
        public async Task<IActionResult> Put(CategoryDTO brandDTO)
        {
            await _categoryService.Update(brandDTO);
            return Ok(brandDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _categoryService.Remove(id);
            return Ok($"Категория с id={id} успешно удалена");
        }
    }
}
