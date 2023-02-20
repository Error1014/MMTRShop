using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMTRShop.DTO.DTO;
using MMTRShop.MiddlewareException.Exceptions;
using MMTRShop.Model.HelperModels;
using MMTRShop.Service.Interface;

namespace MMTRShopAPI.Controllers
{

    public class CartsController : BaseApiController
    {
        private readonly ICartService _cartService;
        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }


        [HttpPost(nameof(GetCartsPage))]
        public async Task<IEnumerable<CartDTO>> GetCartsPage([FromBody] FilterByClient filter)
        {
            var carts = await _cartService.GetCarts(filter);
            return carts;
        }
        [HttpGet("{id}")]
        public async Task<CartDTO> GetCart(Guid id)
        {
            var user = await _cartService.GetCart(id);
            if (user == null)
            {
                throw new NotFoundException("Элемент корзины не найден");
            }
            return user;
        }

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
