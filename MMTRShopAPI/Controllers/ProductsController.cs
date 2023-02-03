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
    public class TestController : ControllerBase
    {
        private readonly ProductService productService;
        private readonly ShopContext _context;
        private readonly UnitOfWork _unitOfWork;

        public TestController(ShopContext context)
{
            _context = context;
            _unitOfWork = new UnitOfWork(context);
            productService = new ProductService(_unitOfWork);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            if (_context==null)
            {
                return NotFound();
            }
            var result =await productService.GetAll();
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
            var product =await productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProducts(Product product)
        {
            productService.AddProduct(product);
            productService.Save();
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
            productService.Save();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(Guid id)
        {
            Product product =await productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            productService.RemoveProduct(product);
            productService.Save();
            return Ok(product);
        }
    }
}
