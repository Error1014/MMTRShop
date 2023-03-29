using Microsoft.AspNetCore.Mvc;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;
using Microsoft.AspNetCore.Authorization;
using Shop.Infrastructure;
using Products.Service.Interfaces;
using Shop.Infrastructure.Attributes;

namespace Products.Api.Controllers
{

    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsPage([FromQuery] ProductPageFilter filter)
        {
            var products = await _productService.GetPageProducts(filter);
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(Guid id)
        {
            var product = await _productService.GetProduct(id);
            return Ok(product);
        }
        [RoleAuthorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> PostProducts(ProductDTO productDTO)
        {
            await _productService.AddProduct(productDTO);
            return Ok(productDTO);
        }
        [RoleAuthorize("Admin Operator")]
        [HttpPut]
        public async Task<IActionResult> PutProduct(ProductDTO productDTO)
        {
            await _productService.Update(productDTO);
            return Ok(productDTO);
        }
        [RoleAuthorize("Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _productService.RemoveProduct(id);
            return Ok($"Продукт с id={id} успешно удалён");
        }
    }
}
