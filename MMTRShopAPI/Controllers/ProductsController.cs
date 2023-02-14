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
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetProductsPage()
        {
            //понять как передать фильтр в качестве параметра когтроллера
            ProductPageFilter filter = new ProductPageFilter(1,5,null,null);
            var products = await _productService.GetPageProducts(filter);
            return products;
        }
        [HttpGet("{id}")]
        public async Task<ProductDTO> GetProduct(Guid id)
        {
            var product = await _productService.GetProduct(id);
            return product;
        }

        [HttpPost]
        public async Task<IActionResult> PostProducts(ProductDTO productDTO)
        {
            _productService.AddProduct(productDTO);
            return Ok(productDTO);
        }

        [HttpPut]
        public async Task<IActionResult> PutProduct(ProductDTO productDTO)
        {
            _productService.Update(productDTO);
            return Ok(productDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            ProductDTO product = await _productService.GetProduct(id);
            _productService.RemoveProduct(product);
            return Ok(product);
        }
    }
}
