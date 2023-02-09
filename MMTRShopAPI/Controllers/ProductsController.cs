using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMTRShop.DTO.DTO;
using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Interface;
using MMTRShop.Service.Services;

namespace MMTRShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsPage(int numPage,int sizePage,Guid? categoryId, Guid? bandId)
        {
            var products = await _productService.GetPageProducts(numPage, sizePage, categoryId, bandId);
            var result = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return result.ToList();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            var product =await _productService.GetProduct(id);

            return product;
        }

        [HttpPost]
        public async Task<IActionResult> PostProducts(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            _productService.AddProduct(product);
            _productService.Save();
            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductDTO productDTO)
        {
            //if (!_context.Product.Any(x => x.Id == product.Id))
            //{
            //    return NotFound();
            //}
            var product = _mapper.Map<Product>(productDTO);
            _productService.Update(product);
            _productService.Save();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            Product product =await _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            _productService.RemoveProduct(product);
            _productService.Save();
            return Ok(product);
        }
    }
}
