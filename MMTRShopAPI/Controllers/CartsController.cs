using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.Exceptions;
using Shop.Infrastructure.HelperModels;
using MMTRShop.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace MMTRShopAPI.Controllers
{
    [Authorize(Roles = "Admin, Client")]
    public class CartsController : BaseApiController
    {
        private readonly ICartService _cartService;
        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IEnumerable<CartDTO>> GetCartsPage([FromQuery] FilterByClient filter)
        {
            var carts = await _cartService.GetCartsDTO(filter);
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
        [HttpPut(nameof(AddCountProductInCart))]
        public async Task<IActionResult> AddCountProductInCart(Guid cartId)
        {
            await _cartService.CartPlusOneProduct(cartId);
            return Ok("+1");
        }
        [HttpPut(nameof(RemoveCountProductInCart))]
        public async Task<IActionResult> RemoveCountProductInCart(Guid cartId)
        {
            await _cartService.CartMinusOneProduct(cartId);
            return Ok("-1");
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
