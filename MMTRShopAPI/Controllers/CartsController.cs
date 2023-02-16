using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMTRShop.DTO.DTO;
using MMTRShop.MiddlewareException.Exceptions;
using MMTRShop.Model.HelperModels;
using MMTRShop.Service.Interface;

namespace MMTRShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : Controller
    {
        private readonly ICartService _cartService;
        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }


        [HttpGet("{clientId}")]
        public async Task<IEnumerable<CartDTO>> GetCartsPage(Guid clientId)
        {
            BaseFilter filter = new BaseFilter(1, 10);
            var carts = await _cartService.GetCarts(clientId, filter);
            return carts;
        }
        //[HttpGet("{id}")]
        //public async Task<CartDTO> GetCart(Guid id)
        //{
        //    var user = await _cartService.GetCart(id);
        //    if (user==null)
        //    {
        //        throw new NotFoundException("Элемент корзины не найден");
        //    }
        //    return user;
        //}

        [HttpPost]
        public async Task<IActionResult> PostCart(CartDTO cartDTO)
        {
            await _cartService.AddProductInCart(cartDTO);
            return Ok(cartDTO);
        }

        [HttpPut]
        public async Task<IActionResult> PutCart(CartDTO cartDTO)
        {
            await _cartService.Update(cartDTO);
            return Ok(cartDTO);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(Guid id)
        {
            await _cartService.RemoveCart(id);
            return Ok($"Пользователь с id={id} успешно удалён"); ;
        }
    }
}
