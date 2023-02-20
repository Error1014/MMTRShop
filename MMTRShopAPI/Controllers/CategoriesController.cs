using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMTRShop.DTO.DTO;
using MMTRShop.Model.HelperModels;
using MMTRShop.Service.Interface;

namespace MMTRShopAPI.Controllers
{

    public class CategoriesController : BaseApiController
    {
        private readonly ICategoryServise _categoryService;
        public CategoriesController(ICategoryServise categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost(nameof(GetCategories))]
        public async Task<IEnumerable<CategoryDTO>> GetCategories([FromBody]BaseFilter filter)
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
