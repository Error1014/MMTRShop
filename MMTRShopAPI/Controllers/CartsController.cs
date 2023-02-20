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

        // редактирование (добавить, удалить товар, количество и тд), возможность очистить корзину)
        [HttpGet]
        public async Task<IEnumerable<CartDTO>> GetCartsPage([FromQuery] FilterByClient filter)
        {
            var carts = await _cartService.GetCarts(filter);
            return carts;
        }

        [HttpPost]
        public async Task<IActionResult> PostProductInCart(CartDTO cartDTO)
        {
            await _cartService.AddProductInCart(cartDTO);
            return Ok(cartDTO);
        }

        [HttpPut]
        public async Task<IActionResult> PutProductInCart(CartDTO cartDTO)
        {
            await _cartService.Update(cartDTO);
            return Ok(cartDTO);
        }
        //3fa85f64-5717-c001-b3fc-2c963f66afa6
        [HttpDelete(nameof(ClearCart))]
        public async Task<IActionResult> ClearCart(Guid clientId)
        {
            await _cartService.ClearCart(clientId);
            return Ok($"Корзина успешно очищена"); ;
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductInCart(Guid clientId, Guid productId)
        {
            await _cartService.RemoveProductInCart(clientId, productId);
            return Ok($"Успешно"); ;
        }
    }
}
