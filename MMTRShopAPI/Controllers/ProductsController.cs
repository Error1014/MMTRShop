using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
using MMTRShop.Repository.Interface;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Interface;
using MMTRShop.Service.Services;
using System.Net.Mail;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace MMTRShopAPI.Controllers
{

    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [Authorize(Roles = "Admin, Client")]
        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetProductsPage([FromQuery] ProductPageFilter filter)
        {
            var products = await _productService.GetPageProducts(filter);
            return products;
        }
        [HttpGet("{id}")]
        public async Task<ProductDTO> GetProduct(Guid id)
        {
            var product = await _productService.GetProduct(id);
            return product;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> PostProducts(ProductDTO productDTO)
        {
            await _productService.AddProduct(productDTO);
            return Ok(productDTO);
        }
        [Authorize(Roles = "Admin, Operator")]
        [HttpPut]
        public async Task<IActionResult> PutProduct(ProductDTO productDTO)
        {
            await _productService.Update(productDTO);
            return Ok(productDTO);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _productService.RemoveProduct(id);
            return Ok($"Продукт с id={id} успешно удалён");
        }
    }
}
