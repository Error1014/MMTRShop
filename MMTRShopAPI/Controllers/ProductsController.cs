using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Services;

namespace MMTRShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ShopContext _context;
        private readonly UnitOfWork _unitOfWork;

        public TestController(ShopContext context)
{
            _context = context;
            _unitOfWork = new UnitOfWork(context);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            if (_context==null)
            {
                return NotFound();
            }
            var result =await _unitOfWork.Products.GetAllAsync();
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
            var product = _unitOfWork.Products.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProducts(Product product)
        {
            _unitOfWork.Products.Add(product);
            _unitOfWork.Products.Save();
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
            _unitOfWork.Products.Save();
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(Guid id)
        {
            Product product = _unitOfWork.Products.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            _unitOfWork.Products.Remove(product);
            _unitOfWork.Products.Save();
            return Ok(product);
        }
    }
}
