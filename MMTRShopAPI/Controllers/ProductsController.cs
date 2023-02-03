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
            var result = _context.Product.ToList();
            if (result == null)
            {
                return NotFound();
            }

            return result;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            if (_context == null)
            {
                return NotFound();
            }
            //var product = _unitOfWork.Brands.GetById(id);
            //if (product == null)
            //{
            //    return NotFound();
            //}
            return null;
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Product>>> PostProducts(Product product)
        {
            //_unitOfWork.Products.Add(product);
            //_unitOfWork.Products.Save();
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }
    }
}
