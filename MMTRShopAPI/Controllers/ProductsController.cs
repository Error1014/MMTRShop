using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMTRShop.DTO.DTO;
using MMTRShop.Model.HelperModels;
using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Interface;
using MMTRShop.Service.Services;
using System.Net.Mail;

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
        public async Task<IEnumerable<ProductDTO>> GetProductsPage()
        {
            //понять как передать фильтр в качестве параметра когтроллера
            ProductPageFilter filter = new ProductPageFilter(1,5,null,null);
            var products = await _productService.GetPageProducts(filter);
            var result = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return result;
        }
        [HttpGet("{id}")]
        public async Task<ProductDTO> GetProduct(Guid id)
        {
            var product = await _productService.GetProduct(id);
            var result = _mapper.Map<ProductDTO>(product);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> PostProducts(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            _productService.AddProduct(product);
            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            _productService.Update(product);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            Product product = await _productService.GetProduct(id);
            _productService.RemoveProduct(product);
            return Ok(product);
        }
    }
}
