using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ShopContext _context = new ShopContext();

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            if (_context==null)
            {
                return NotFound();
            }
            var result =await _productService.GetAll();
            if (result == null)
            {
                return NotFound();
            }

            return result.ToList();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            if (_context == null)
            {
                return NotFound();
            }
            var product =await _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProducts(Product product)
        {
            _productService.AddProduct(product);
            _productService.Save();
            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<Product>> Put(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            if (!_context.Product.Any(x => x.Id == product.Id))
            {
                return NotFound();
            }
            _context.Update(product);
            _productService.Save();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(Guid id)
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
